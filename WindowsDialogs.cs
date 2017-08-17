using UnityEngine; 
using System.Collections;
using System;
using System.Runtime.InteropServices;
/// <summary> 
/// Specifies identifiers to indicate the return value of a dialog box. 
/// </summary> 
public enum DialogResult 
{ 
  /// <summary> 
  /// Nothing is returned from the dialog box. This means that the modal dialog 
  /// continues running. 
  /// </summary> 
  None = 0, 
  /// <summary> 
  /// The dialog box return value is OK (usually sent from a button labeled OK). 
  /// </summary> 
  OK = 1, 
  /// <summary> 
  /// The dialog box return value is Cancel (usually sent from a button labeled 
  /// Cancel). 
  /// </summary> 
  Cancel = 2, 
  /// <summary> 
  /// The dialog box return value is Abort (usually sent from a button labeled 
  /// Abort). 
  /// </summary> 
  Abort = 3, 
  /// <summary> 
  /// The dialog box return value i~ Retry (usually sent from a button labeled 
  /// Retry). 
  /// </summary> 
  Retry = 4, 
  /// <summary> 
  /// The dialog box return value is Ignore (usually sent from a button labeled 
  /// Ignore). 
  /// </summary> 
  Ignore = 5, 
  /// <summary> 
  /// The dialog box return value is Yes (usually sent from a button labeled 
  /// Yes) . 
  /// </summary> 
  Yes = 6, 
  /// <summary> 
  /// The dialog box return value is No (usually sent from a button labeled No). 
  /// </summary> 
  No = 7, 
}

/// <summary> 
/// Specifies constants defining which buttons to display on a MessageBox. 
/// </summary> 
public enum MessageBoxButtons 
{ 
  /// <summary> 
  /// The message box contains an OK button. 
  /// </summary> 
  OK = 0,
  /// <summary> 
  /// The message box contains OK and Cancel buttons. 
  /// </summary> 
  OKCancel = 1,
  /// <summary> 
  /// The message box contains AbortJ RetrYJ and Ignore buttons. 
  /// </summary> 
  AbortRetryIgnore = 2,
  /// <summary> 
  /// The message box contains YesJ NOJ and Cancel buttons. 
  /// </summary> 
  YesNoCancel = 3,
  /// <summary> 
  /// The message box contains Yes and No buttons. 
  /// </summary> 
  YesNo = 4,
  /// <summary> 
  /// The message box contains Retry and Cancel buttons. 
  /// </summary> 
  RetryCancel = 5,
} 

/// <summary> 
/// Specifies constants defining which information to display. 
/// </summary> 
public enum MessageBoxIcon 
{ 
  /// <summary> 
  /// The message box contain no symbols. 
  /// </summary> 
  None = 0,
  /// <summary> 
  /// The message box contains a symbol consisting of white X in a circle with a red background. 
  /// </summary> 
  Error = 16,
  /// <summary> 
  /// The message box contains a symbol consisting of a question mark in a circle. 
  /// </summary> 
  Question = 32,
  /// <summary> 
  ///The message box contains a symbol consisting of an exclamation point in a 
	/// 	triangle with a yellow background. 
  /// </summary> 
  Warning = 48,
  /// <summary> 
  /// The message box contains a symbol consisting of a lowercase letter i in a 
	/// 	circle. 
  /// </summary> 
  Information = 64 
} 

/// <summary> 
/// Displays a message window, also known as a dialog box, which presents a message 
/// 	to the user. It is a modal window, blocking other actions in the application 
/// 	until the user closes it. A MessageBox can contain text, 
/// 	buttons, and symbols that inform and instruct the user. 
/// </summary> 
public static class MessageBox 
{ 
  private static class DllTest 
  { 
    [DllImport(·User32.dll·, SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)] 
    public static extern int MessageBox([In, Optional] IntPtr hWnd, [In, Optional] string text, [In, Optional] string title, [In] uint uType);
  } 
  /// <summary> 
  /// Displays a message box with specified text. 
  /// </summary> 
  /// <param name="text">The text to display in the message box.</param> 
  /// <returns>One of the DialogResult values.</returns> 
  public static DialogResult Show(string text) 
  { 
    return (DialogResult)DllTest.MessageBox(IntPtr.Zero, text, "", 0);
  } 
  /// <summary> 
  /// Displays a message box with specified text and caption. 
  /// </summary> 
  /// <param name="text">The text to display in the message box.</param> 
  /// <param name="caption">The text to display in the title bar of the message box.</param> 
  /// <returns>One of the DialogResult values.</returns> 
  public static DialogResult Show(string text, string caption) 
  { 
    return (DialogResult)DllTest.MessageBox(IntPtr.Zero, text, caption, 0);
  } 
  /// <summary> 
  /// Displays a message box with specified text, caption, and buttons. 
  /// </summary> 
  /// <param name="text">The text to display in the message box.</param> 
  /// <param name="caption">The text to display in the title bar of the message box.</param> 
  /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the message box.</param> 
  /// <returns>One of the DialogResult values.</returns> 
  public static DialogResult Show(string text, string caption,MessageBoxButtons buttons) 
  { 
    uint ubuttons = (uint)buttons;
    return (DialogResult)DllTest.MessageBox(IntPtr.Zero, text, caption, ubuttons);
  } 
  public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBox1con icon) 
  { 
    uint ubuttons = (uint)buttonsj 
    ubuttons += (uint)iconj 
    return (DialogResult)DllTest.MessageBox(IntPtr.Zero, text, caption, ubuttons);
  } 
} 

public class ColorDialog 
{ 
  private ChooseColor CCj;
  /// <summary> 
  /// Gets or sets the color selected by the user. 
  /// </summary> 
  public Color Color = new Color(0, 0, 0); 
  //Win32API Class for function 
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)] 
  private class ChooseColor 
  { 
    public Int32 structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero; 
    public Int32 rgbResult;
    public string custColors = null;
    public Int32 flagsEx = e;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public string templateName = null;
  } 
  //Exposing ColorDialog from Comdlg32 
  private class DllTest 
  { 
    [Dlllmport(nComdlg32.dlln, SetLastError = false, ThrowOnUnmappableChar = false, CharSet = CharSet.Auto)] 
    public static extern bool ChooseColor([In, Out] ChooseColor cC);
    public static bool ChooseColorl([In, Out] ChooseColor cc) 
    { 
      return ChooseColor(cc);
    } 
  }
  
  public ColorDialog() 
  { 
    cc = new ChooseColor();
    cc.structSize = Marshal.SizeOf(cc);
    cc.custColors = new string(new char[16]);
  } 
  public bool Show() 
  { 
    cc.flagsEx = 0x00000002 | 0x00000001; 
    if (DllTest.ChooseColorl(cc))
    { 
      string asBytes = cc.rgbResult.ToString("X6");
      int Color_r = int.Parse(asBytes.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
      int Color_g = int.Parse(asBytes.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
      int Color_b = int.Parse(asBytes.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
      Color = new Color(Color_r / 255f, Color_g / 255f, Color_b / 255f);
      return true ; 
    } 
    return false; 
  } 
}

public class OpenFileDialog 
{ 
  private Open FileName ofn;
  /// <summary> 
  /// 	Gets or sets the current file name filter string, which determines the choices 
  ///   that appear in the "Save as file type" or "Files of type" box in the dialog box.
  /// </summary> 
  public string Filter = "All files\0*.*\0\0";
  /// <summary> 
  /// Gets or sets the initial directory displayed by the file dialog box. 
  /// </summary> 
  public string InitialDirectory = UnityEngine.Application.dataPath;
  /// <summary> 
  /// Gets or sets the file dialog box title. 
  /// </summary> 
  public string Title = "";
  /// <summary> 
  /// Gets or sets a value indicating whether the dialog box allows multiple files 
  /// to be selected. 
  /// </summary> 
  public bool Multiselect = false;
  /// <summary> 
  /// Gets or sets the default file name extension. 
  /// </summary> 
  public string DefaultExt = "";
  /// <summary> 
  /// Gets or sets a string containing the file name selected in the file dialog 
  /// box. 
  /// </summary> 
  public string FileName = "";
  
  //Win32API Class for function 
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)] 
  private class OpenFileName 
  { 
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero; 
    public string filter = null;
    public string customFilter = null;
    public int maxCustFilter = 0;
    public int filterlndex = 0;
    public string file = null; 
    public int maxFile = 0;
    public string fileTitle = null;
    public int maxFileTitle = 0;
    public string initialDir = null;
    public string title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public string defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public string templateName = null; 
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedlnt = 0;
    public int flagsEx = 0;
  } 
  //Exposing GetOpenFileName from Comdlg32 
  private class DllTest 
  { 
    [Dlllmport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)] 
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
    public static bool GetOpenFileNamel([In, Out] OpenFileName ofn) 
    { 
      return GetOpenFileName(ofn);
    } 
  } 
  
  public OpenFileDialog() 
  { 
    ofn = new OpenFileName();
    //Sets in advance the class size 
    ofn.structSize = Marshal.SizeOf(ofn);
    //Sets Default parameters for not moving this struct until overflow is needed: 
    ofn.file = new string(new char[256]); 
    ofn.maxFile = ofn.file.Length;
    ofn.fileTitle = new string(new char[64]);
    ofn.maxFileTitle = ofn.fileTitle.Length;
    ofn.flags = 0x00080000 //OFN_Explorer
      | 0x00001000         //OFN_FileMustExist
      | 0x00000800         //OFN_PathMustExist
      | 0x00000008;        //OFN_NoChangeDir
  } 
  public bool Show() 
  { 
    ofn.defExt = DefaultExt;
    ofn.filter = Filter;
    ofn.initialDir = InitialDirectory;
    ofn.title = Title;
    if (Multiselect) 
    { 
      ofn.flags += 0x00000200; //OFN_AllowMultiSelect
    } 
    if (DllTest.GetOpenFileName(ofn))
    { 
      FileName = ofn.file;
      return true;
    } 
    return false;
  }
}
