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
            bool done = false;
            object[] values = new object[Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories).Length + Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories).Length];
            Nullable<int>[] parents = new int[values.Length];
            values[0] = from.FullName;
            parents[0] = null;
            int index = 1;
            while(!done) {
                string[] files = Directory.GetFiles(from.FullName, "*", SearchOption.TopDirectoryOnly);
                string[] directories = Directory.GetDirectories(from.FullName, "*", SearchOption.TopDirectoryOnly);
                string[] currentValues = new string[files.Length + directories.Length];
                for(int i = 0; i < files.Length; i++) {
                    values[index + i] = files[i].FullName;
                    parents[index + i] = index;
                }
                index += files.Length;
            }
        }
        public void StartChonk() {
        
        }
        public void TransferFiles(DirectoryInfo source, DirectoryInfo target) {
            if (source.FullName.ToLower() == target.FullName.ToLower()) {
                return;
            }
            if (Directory.Exists(target.FullName) == false) {
                Directory.CreateDirectory(target.FullName);
            }
            foreach (FileInfo file in source.GetFiles()) {
                file.CopyTo(Path.Combine(target.ToString(), file.Name), true);
            }
            foreach (DirectoryInfo directorySourceSub in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(directorySourceSub.Name);
                TransferFiles(directorySourceSub, nextTargetSubDir);
            }
        }
    
        public static long DirectorySize(DirectoryInfo directory) {
            long size = 0;
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files) {
                size += file.Length;
            }
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo directoryInfo in directories) {
                size += DirectorySize(directoryInfo);
            }
            return size;
        }
    }
}