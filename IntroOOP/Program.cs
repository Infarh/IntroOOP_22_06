using NStack;

using Terminal.Gui;

//var file = new FileInfo("c:\\123");

//file.Attributes |= FileAttributes.Archive;
//file.Attributes &= ~FileAttributes.Archive;

//var dir = new DirectoryInfo("c:\\123");
//dir.EnumerateFiles()
//dir.GetFiles();
//var drives = DriveInfo.GetDrives();

//File.Create()
//Directory.EnumerateFiles("c:\\123", "*.*").ToArray();

//Directory.GetFiles("c:\\123", "*.*")
//Directory.EnumerateFiles("c:\\123", "*.*")

//if (Directory.GetFiles("c:\\123", "*.*").Length > 0)
//{

//}

//if (Directory.EnumerateFiles("c:\\123", "*.*").Any())
//{
//    var total_length = Directory.EnumerateFiles("c:\\123", "*.*", SearchOption.AllDirectories)
//       .Sum(file => file.Length);
//}


Application.Init();
var top = Application.Top;

var window = new Window("Файловый менеджер")
{
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill(),
};
top.Add(window);

var menu = new MenuBar(new MenuBarItem[] {
    new MenuBarItem ("_File", new MenuItem [] {
        new MenuItem ("_New", "Creates new file", null),
        new MenuItem ("_Close", "",null),
        new MenuItem ("_Quit", "", () => { if (Quit()) top.Running = false; })
    }),
    new MenuBarItem ("_Edit", new MenuItem [] {
        new MenuItem ("_Copy", "", null),
        new MenuItem ("C_ut", "", null),
        new MenuItem ("_Paste", "", null)
    })
});

static bool Quit()
{
    var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
    return n == 0;
}
top.Add(menu);

var login = new Label("Login: ") { X = 3, Y = 2 };
var password = new Label("Password: ")
{
    X = Pos.Left(login),
    Y = Pos.Top(login) + 1
};

var loginText = new TextField("")
{
    X = Pos.Right(password),
    Y = Pos.Top(login),
    Width = 40
};
var passText = new TextField("")
{
    Secret = true,
    X = Pos.Left(loginText),
    Y = Pos.Top(password),
    Width = Dim.Width(loginText)
};

window.Add(
    login, password, loginText, passText,

    new CheckBox(3, 6, "Remember me"),
    new RadioGroup(3, 8, new ustring[] { "_Personal", "_Company" }, 0),
    new Button(3, 14, "Ok"),
    new Button(10, 14, "Cancel"),
    new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar")
);

Application.Run();
Application.Shutdown();
