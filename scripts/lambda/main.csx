Func<DateTime, bool> canDrive = dob => {
  return dob.AddYears(18) <= DateTime.Today;
};

DateTime dob = new DateTime(2002, 12, 25);
bool result = canDrive(dob);
Console.WriteLine(result);

Action<DateTime> printDate = date => Console.WriteLine(date);

DateTime date = DateTime.Today;
printDate(date);

Func<string, string, string> concatFirstAndLastName = (nome, cognome) => {
  return nome + " " + cognome;
};

string nome = "Giuseppe", cognome = "Fagnani";
string nomeCompleto = concatFirstAndLastName(nome, cognome);
Console.WriteLine(nomeCompleto);

Func<int, int, int, int> getMaximum = (a, b, c) => {
  int max = a;
  int m = b;
  if (b >= c) m = b;
  else m = c;
  if (a >= m) return a;
  else return m;
};

Console.WriteLine(getMaximum(12,10,4));

Action<DateTime, DateTime> printLowerDate = (date1, date2) => {
  if (date1 >= date2) Console.WriteLine(date2);
  else Console.WriteLine(date1);
};

printLowerDate(new DateTime(1993,1,2), new DateTime(1996,2,24));