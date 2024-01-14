using Man_RaduLab11.Data;
namespace Man_RaduLab11;

public partial class App : Application
{
    public static ShoppingListDatabase Database { get; private set; }

    public App()
	{
        Database = new ShoppingListDatabase(new RestService());
        MainPage = new NavigationPage(new ListEntryPage());
	}
}

