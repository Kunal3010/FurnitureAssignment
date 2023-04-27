namespace FurnitureShop
{
    class Furniture
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Color { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        public void Accept()
        {
            Console.Write("Enter height: ");
            Height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter width: ");
            Width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter color: ");
            Color = Console.ReadLine();

            Console.Write("Enter quantity: ");
            Qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter price: ");
            Price = Convert.ToDouble(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Width: " + Width);
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Price: " + Price);
        }

    }
    class BookShelf : Furniture
    {
        public int NoOfShelves { get; set; }
        public new void Accept()
        {
            base.Accept();
            Console.Write("Enter number of shelves: ");
            NoOfShelves = Convert.ToInt32(Console.ReadLine());
        }
        public new void Display()
        {
            base.Display();
            Console.WriteLine("Number of shelves: " + NoOfShelves);
        }
    }
    class DiningTable : Furniture
    {
        public int NoOfLegs { get; set; }
        public new void Accept()
        {
            base.Accept();
            Console.Write("Enter number of legs: ");
            NoOfLegs = Convert.ToInt32(Console.ReadLine());
        }
        public new void Display()
        {
            base.Display();
            Console.WriteLine("Number of legs: " + NoOfLegs);
        }
    }

    internal class Program
    {
        static int AddToStock(Furniture[] stock)
        {
            int count = 0;
            Console.WriteLine("\t \t \t Adding Furniture to the Stocks");

            while (count < stock.Length)
            {
                Console.WriteLine();
                Console.WriteLine("Type 1 for BookShelf \nType 2 for Dinning Table");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Bookshelf");
                        stock[count] = new BookShelf();
                        break;

                    case 2:
                        Console.WriteLine("Dining Table");
                        stock[count] = new DiningTable();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, Try again");
                        continue;
                }

                stock[count].Accept();
                count++;
            }
            return count;
        }
        static double TotalStockValue(Furniture[] stock)
        {
            double total = 0;
            foreach(Furniture f in stock)
            {
                total += f.Price * f.Qty;
            }
            return total;
        }
        static void ShowStockDetails(Furniture[] stock)
        {
            foreach(Furniture st in stock)
            {
                st.Display();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Furniture[] stock = new Furniture[5];
            int items = AddToStock(stock);
            ShowStockDetails(stock);
            double cost = TotalStockValue(stock);
            Console.WriteLine($"The Total Cost of your Product is {cost}");
        }
    }
}
