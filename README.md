# Unity3d-WIN32API
using win32 api for unity3d desktop applications

today you can use directrly the system32 dlls that are in you computer with some reflection tricks that are available through c#.
The core idea of this project is to wrap those abilities the anyone who is developing inside Unity could open the basic dialogs of windows from within his windows-desktop-unity-application.

today i already wrapped 3 basic Dialogs:
1. OpenFileDialog
2. MessageBox (Static implentation)
3. ChooseColorDialog (implemented for basic use only)

by puting the code file inside your unity project you can use the C# classe as you used to.

An example for using OpenFileDialog:

OpenFileDialog ofd = new OpenFileDialog(); 
ofd.filter = "All files/0*.*/0PNG files(*.png)/0*.png/0/0";
if (ofd.Show())
{
  Debug.Log(ofd.file)
}

An simple example for using MessageBox:
MessageBox.Show("This is the title","This is the text!");

Or a more complex one:
if (MessageBox.Show("","There are two buttons", MessageBoxButtons.MessageBoxButtons) == DialogResult.OK)
{
  MessageBox.Show("Suprise!","You clicked OK");
}

Please fill free to wrap more functions inside this git
