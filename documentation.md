# FolderChunking Official Documentation

You can use FolderChunking as a normal person or as a developer. To get started with the basic stuff you need [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed. After you have that you can either run [run.sh](run.sh) or type `dotnet run` in the terminal in the FolderChunking folder. You may need to grant extra permission for the program to execute correctly. Once you run the code follow the instructions to start the file transfer. When inserting the directory locations use the full name with parent foldres and all that. Saved directory locations are stored in [paths.txt](paths.txt), and are seperated by `&`.

## Developer stuff

[Program.cs](Program.cs) contains all the code to get started on the console, but if you want to you can edit and modify all of the files as you wish. The `System` and `System.IO` namespaces contain all of the custom classes/structs of the project.
### `System.IO.Chunker`
The class to get started with the folder chunking. It contains the source and target directories, as well as many functions for directory/tree manipulation.
```cs
public void GenerateTree()
```
Creates the directory tree for chunking. Very memory intense at the start, but it's worth it if you have a lot of data.
```cs
public void StartChonk()
```
Well... starts the chonking behaviour.
```cs
public static void TransferFiles(DirectoryInfo source, DirectoryInfo target)
```
Copies the files from `source` to `target`. Currently in it's very early stage, so it's not the fastest.
```cs
public static long DirectorySize(DirectoryInfo directory)
```
Returns the size (in bytes) of the given directory.
### `System.Tree`
The basic class that holds a tree. Here it is used to represent the folder structure.
```cs
public Tree(object[] values, string[] parents)
```
`values` is the array of values that the individual nodes hold. `parents` is the array of node parent paths.
```cs
public TreeNode GetNode(int index)
```
Returns the node of the given index.
### `System.TreeNode`
The class that represent a node in the tree. It holds a value and maybe a parent.
```cs
public TreeNode(object value)
```
Creates a node with the value `value`.
```cs
public TreeNode(object value, string parent)
```
Creates a node with the value `value` and parent `parent`.

This is not at all the finished version! I plan to add a much more in-depth guide, but for now it'll do just fine