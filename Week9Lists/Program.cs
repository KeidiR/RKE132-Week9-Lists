//listid - paindlikumad kui massiivid. Listi loomine nõuab argumenti. Ühes listis võib ola ainult ühte tüüpi andmed
// string --> string, int(täisarvud) --> int jne
//ostunimekirja rakendus

string folderPath = @"D:\Kool\ProgrammeerimiseAlgkursus\Data";
string fileName = "shoppinglist.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<string>();

if (File.Exists(filePath))//kontrollin kas fail eksisteerib. fail on --> true, faili pole --> false
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    File.Create(filePath).Close();//kindlasti peab .Close()
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}



static List<string> GetItemsFromUser() //List<> --> mida soovime tagastada vahemälusse
{
List<string> userList = new List<string>();//listid on kasulikud kui me ei oska ette öelda, mitu asja me soovime listi sisse kirjutada
//kõige pealt salvestame andmed vahemälusse
//List käitub nagu massiiv. Count - 1 kohal.
while (true)
{
    Console.WriteLine("Add an item (add)/ Exit (exit):");
    string userChoice = Console.ReadLine();//loeme vahemälusse

    if (userChoice == "add")
    {
        Console.WriteLine("Enter an item:");
        string userItem = Console.ReadLine();
        userList.Add(userItem);//userItem lisatakse(Add) myShoppingList-i
    }
    else
    {
        Console.WriteLine("Bye!");
        break;
    }
}
return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    //List pikkus --> Count
    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1;//loetelu nummerdamiseks. Väljaspool foreachi, sest muidu oleks i koguaeg 1, olenemata i++-st.

    foreach (string item in someList)//foreach elementide kuvamiseks
    {
        Console.WriteLine($"{i}. {item}");
        i++;//loetelu nummerdamiseks
    }
}


