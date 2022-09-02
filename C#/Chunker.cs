namespace System.IO {
    using System;
    public class Chunker {
        public string from;
        public string to;
        public Tree tree;
    
        public Chunker(string from, string to) {
            from = from;
            to = to;
        }

        public void GenerateTree() {
            tree = new Tree();
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
                file.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
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