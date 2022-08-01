string password = String.Empty;
bool isValid = false;
while (password == String.Empty || password.Length<8 || !isValid)
{
    Console.WriteLine("Podaj hasło. Minimum 8 znaków, jedna cyfra, jedna wielka litera i znak specjalny");
    password = Console.ReadLine();
    isValid = Validate(password);
}

Console.WriteLine($"Hasło przed zaszyfrowaniem: {password}");
password = Encrypt(password);
Console.WriteLine($"Hasło po zaszyfrowaniu: {password}");
password = Decrypt(password);
Console.WriteLine($"Hasło po ponownym odszyfrowaniu: {password}");
Console.ReadKey();


static bool Validate(string password)
{
    bool firstTerm = false;
    bool secondTerm = false;
    bool thirdTerm = false;
    foreach (char sign in password)
    {
        if (Char.IsUpper(sign)) firstTerm = true;
        if (Char.IsDigit(sign)) secondTerm = true;
        if (!Char.IsWhiteSpace(sign)) thirdTerm = true;
    }
    Console.WriteLine($"1:{firstTerm}2:{secondTerm}3:{thirdTerm}\n");
    if (firstTerm && secondTerm && thirdTerm) return true;
    return false;
}

static string Encrypt(string password)
{
    int[] passArray=MakeItArray(password);
    for (int i = 0; i < passArray.Length; i++)
    {
        passArray[i] += 1;
    }

    char[] tempArray = new char[passArray.Length];
    for (int i = 0; i < passArray.Length; i++)
    {
        tempArray[i] = (char)passArray[i];
    }

    password = tempArray.ToString();
    return password;
}

static string Decrypt(string password)
{
    int[] passArray=MakeItArray(password);
    for (int i = 0; i < passArray.Length; i++)
    {
        passArray[i]-=1;
    }

    
    

    password = tempArray.ToString();
    return password;
}

static int[] MakeItArray(string password)
{
    char[] passArray = password.ToCharArray();
    int[] tempArray = new int[passArray.Length];
    for (int i = 0; i < passArray.Length; i++)
    {
        tempArray[i] = (int)passArray[i];
        Console.WriteLine($"{tempArray[i]}\t{passArray[i]}");
    }

    Console.ReadKey();
    return tempArray;
}