using System.Text;

string password=String.Empty;
bool isValid = false;
while (password.Length<8 || !isValid)
{
    Console.WriteLine("Podaj hasło. Minimum 8 znaków, jedna wielka litera, jedna cyfra oraz znak specjalny");
    password = Console.ReadLine();
    isValid = CheckPass(password);
}

Console.WriteLine($"Hasło przed zaszyfrowaniem: {password}");
password = MakePassword(password,1);
Console.WriteLine($"Hasło po zaszyfrowaniu: {password}\nNaciśnij dowolny klawisz...");
password = MakePassword(password, -1);
Console.ReadKey();
Console.WriteLine($"Hasło po odszyfrowaniu: {password}");

Console.ReadKey();

static string MakePassword(string password,int number)
{
    int[] numbersArray = new int[password.Length];
    char[] signsArray = new char[password.Length];  
    for (int i = 0; i < password.Length; i++)
    {
        signsArray[i] = password[i];
        numbersArray[i] = (int)signsArray[i];
        signsArray[i] = (char)(numbersArray[i] + (2*number));
    }

    return new string(signsArray);
}

static bool CheckPass(string password)
{
    bool firstTerm = false;
    bool secondTerm = false;
    bool thirdTerm = false;
    foreach (char sign in password)
    {
        if (Char.IsDigit(sign)) firstTerm = true;
        if (Char.IsUpper(sign)) secondTerm = true;
        if (Char.IsSymbol(sign) || Char.IsPunctuation(sign)) thirdTerm = true;
        
    }

    return firstTerm && secondTerm && thirdTerm;
}