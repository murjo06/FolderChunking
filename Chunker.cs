namespace System.IO {
    using System;
    public class Chunker {
        public DirectoryInfo from;
        public DirectoryInfo to;
        public Tree tree;
    
        public Chunker(string from, string to) {
            this.from = new DirectoryInfo(from);
            this.to = new DirectoryInfo(to);
        }

        public void GenerateTree() {
            object[] values = new object[Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories).Length + Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories).Length + 1];
            string[] parents = new string[values.Length];
            values[0] = from.FullName;
            parents[0] = "";
            string[] files = Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories);
            string[] currentValues = new string[files.Length + directories.Length];
            files.CopyTo(currentValues, 0);
            directories.CopyTo(currentValues, files.Length);
            for(int i = 1; i <= currentValues.Length; i++) {
                values[i] = currentValues[i];
                parents[i] = Directory.GetParent(currentValues[i]).FullName;
            }
            tree = new Tree(values, parents);
        }
        public void StartChonk() {
            TransferFiles(from, to);
        }

        public static void TransferFiles(DirectoryInfo source, DirectoryInfo target) {
            if(source.FullName.ToLower() == target.FullName.ToLower()) {
                return;
            }
            if(Directory.Exists(target.FullName) == false) {
                Directory.CreateDirectory(target.FullName);
            }
            foreach(FileInfo file in source.GetFiles()) {
                file.CopyTo(Path.Combine(target.ToString(), file.Name), true);
            }
            foreach(DirectoryInfo directorySourceSub in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(directorySourceSub.Name);
                TransferFiles(directorySourceSub, nextTargetSubDir);
            }
        }
        public static long DirectorySize(DirectoryInfo directory) {
            long size = 0;
            foreach (FileInfo file in directory.GetFiles()) {
                size += file.Length;
            }
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories()) {
                size += DirectorySize(directoryInfo);
            }
            return size;
        }
    }
}