class Apple {
  public string Color {get; set;}
  public int Weight {get; set;}
}

List<Apple> apples = new List<Apple> {
  new Apple {Color = "Red", Weight = 180},
  new Apple {Color = "Green", Weight = 195},
  new Apple {Color = "Red", Weight = 190},
  new Apple {Color = "Green", Weight = 185}
};

IEnumerable<int> weightsOfRedApples = apples
                      .Where(apple => apple.Color == "Red")
                      .Select(apple => apple.Weight);
int minimumWeight = apples.Min(apple => apple.Weight);
string color = apples.Where(apple => apple.Weight==190).Select(apple => apple.Color).ElementAtOrDefault(0);
double average = weightsOfRedApples.Average();
int redAppleCount = apples.Where(apple => apple.Color=="Red").Count();
int totalWeight = apples.Where(apple => apple.Color=="Green").Sum(apple => apple.Weight);
Console.WriteLine($@"minimumWeight = {minimumWeight}    average = {average}
color = {color}   redAppleCount = {redAppleCount}   totalWeight = {totalWeight}");