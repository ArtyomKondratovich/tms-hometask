using MyToDoList;
using MyToDoList.Data;
using System.IO;

var data = new DataHandler(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\data.json"));

new Menu(data).Start();