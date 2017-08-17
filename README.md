# Unity3d-WIN32API
using win32 API for unity3d desktop applications

today you can use directrly the system32 dlls that are inside your computer with some reflection tricks that are available through c#.
The core idea of this project is to wrap those abilities and to enable the basic dialogs of windows from within windows-desktop-unity-application.

today i already wrapped 3 basic Dialogs:
1. OpenFileDialog
2. MessageBox (Static implentation)
3. ChooseColorDialog (implemented for basic use only)

by puting the code file inside your unity project you can use the C# classe as you used to.

An example for using OpenFileDialog:

```csharp
OpenFileDialog ofd = new OpenFileDialog(); 
ofd.filter = "All files/0*.*/0PNG files(*.png)/0*.png/0/0";
if (ofd.Show())
{
  Debug.Log(ofd.file)
}
```

An simple example for using MessageBox:
```csharp
MessageBox.Show("This is the title","This is the text!");
```
Or a more complex one:
```csharp
if (MessageBox.Show("","There are two buttons", MessageBoxButtons.MessageBoxButtons) == DialogResult.OK)
{
  MessageBox.Show("Suprise!","You clicked OK");
}
```
Please fill free to wrap more functions inside this git
