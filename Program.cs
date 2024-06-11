namespace OceanSubmarinePraject {
    internal class Program {
            //funciotn being call
        static void Main(string[] args) {

            UncardedWater();

            //SPACE
            space(4);





        }//end main

        static void UncardedWater() {
            //collor background to look like the ocean
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            //show all of the variables and text asked 
            Console.WriteLine($"\n============================================\n--------------------------------------------\n\t===>  Uncharted Water  <===\n--------------------------------------------\n============================================");
            space(1);
            Console.WriteLine("\t     Data\n--------------------------------");

            int[,,] satellitedata = GetSatelliteData();
            int z = 0;
            double surfaceSubmarineData = SubmarineData(satellitedata, z);
            Console.WriteLine($"  Surface Sub Dinsity     *{Math.Round(surfaceSubmarineData, 2)}\n");
            double underSubmarineData = SubmarineData(satellitedata,z+1);
            Console.WriteLine($"  Underwater Sub Dinsity  *{Math.Round(underSubmarineData, 2)}\n");
            double deepSubmarineData = SubmarineData(satellitedata,z+2);
            Console.WriteLine($"  Deepwater Sub Dinsity   *{Math.Round(deepSubmarineData, 2)}\n--------------------------------\n");
            Console.WriteLine($"\t     Ratio\n--------------------------------");
            double submarineRatio = SubmarineRatio(satellitedata);
            Console.WriteLine($"  Us Navy Sub/ Enemy Sub  *{Math.Round(submarineRatio, 2)}\n--------------------------------\n");
            bool surfaceShouldAttack = ShouldAttack(satellitedata, z);
            Console.WriteLine($"\t\tShould Attack\n-------------------------------------------------");
            Console.WriteLine($"  Go for surface attack     *{surfaceShouldAttack}");
            if ( surfaceShouldAttack ) {
                Console.WriteLine("  Submarines on the surface should attack\n\n");
            }else {
                Console.WriteLine("  Submarines on the surface should Not attack\n\n");
            }//end if else 
            bool underShouldAttack = ShouldAttack(satellitedata, z + 1);
            Console.WriteLine($"  Go for underwatter attack  *{underShouldAttack}");
            if (underShouldAttack) {
                Console.WriteLine("  Submarines on the underwater should attack\n\n");
            } else {
                Console.WriteLine("  Submarines on the underwater should Not attack\n\n");
            }//end if else 
            bool deepShouldAttack = ShouldAttack(satellitedata, z + 2);
            Console.WriteLine($"  Go for deepwater attack    *{deepShouldAttack}");
            if (deepShouldAttack) {
                Console.WriteLine("  Submarines on the deep water should attack\n-------------------------------------------------");
            } else {
                Console.WriteLine("  Submarines on the deep water should Not attack\n-------------------------------------------------");
            }//end if else 


            Collor(satellitedata);
            GetSatelliteData();

            Console.ResetColor();
            space(1);


            
                
        }//end fucntion 

        static void Collor(int[,,]data) {
            //shows the Text for the three
            //space between the first and the arrays
            space(2);
            for (int z = 0; z < data.GetLength(2); z++) {
                if (z == 0) {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (z == 1) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                if (z == 2) {
                    Console.ForegroundColor = ConsoleColor.Black;
                }//end if tree

                string[] layerlabel = { "\t\tSurface\n-----------------------------------------", "\t       UnderWater\n-----------------------------------------", "\t\tDeepWater\n-----------------------------------------" };
                Console.WriteLine(layerlabel[z]);
                Display(data, z);
                space(2);
            }//end for look


        }//end fucntion

        static int[,,] GetSatelliteData() {
            //Variables
            Random rand = new Random();
            int[,,] data = new int[10,10,3];
            for (int z = 0; z < data.GetLength(2); z++) {
                for (int y = 0; y < data.GetLength(1); y++) {
                    for (int x = 0; x < data.GetLength(0); x++) {
                        if (rand.Next(0,101) < 25) {
                            data[x,y,z] = rand.Next(3);
                        }//end if
                    }//end x
                }//end y
            }//end z
            return data;
        }//end fucnton 

        static void Display(int[,,] data, int z) {

            for (int y = 0;y < data.GetLength(0); y++) {
                for (int x = 0;x < data.GetLength(1); x++) {
                    Console.Write($"  {data[x,y,z]} ");
                }//end x
                space(1); 
            }//end y
        }//end fucntion 

        static double SubmarineRatio(int[,,] data) {
            int navySub = 0;
            int enemySub = 0;

            for(int z= 0; z < data.GetLength(2); z++) {
                for (int y= 0; y < data.GetLength(1); y++) {
                    for (int x= 0; x < data.GetLength(0); x++) {
                        if (data[x, y, z] == 1) {
                            navySub++;
                        } if (data[x, y, z] == 2) {
                            enemySub++;
                        }//end if tree
                    }//end x
                }//end y
            }//end z
            return (double)navySub / (double)enemySub;
        }//end fucntion

        static bool ShouldAttack(int[,,] data, int z) {
            int navysubs= 0;
            int enemysubs= 0;
            for (int y =0 ; y < data.GetLength(1); y++) { 
                for (int x = 0; x < data.GetLength(0); x++) {
                    if ((data[x, y, z] == 2)) {
                        enemysubs++;
                    }else if ((data[x, y, z] == 1)) {
                        navysubs++;
                    }//end if esle 
                }//end x
            }//end y
            return navysubs > enemysubs;
        }//end fuciton

        static double SubmarineData(int[,,]data,int z) {

            int submarinesNum = 0;
            int totalCells = data.GetLength(0) * data.GetLength(1);

            for (int y = 0; y < data.GetLength(0); y++) {
                for (int x = 0; x < data.GetLength(1); x++) {
                    if (data[x, y, z] == 1|| data[x,y,z]==2) {
                        submarinesNum++;

                    }//end if
                }//edn for x
            }//end for y 
            return (double)submarinesNum/totalCells;
        }//end funciton



        static void space (int space){
            for (int i = space; 0 < i; i--) { 
                Console.WriteLine();
                if (i == 0) {
                    break;
                }//end if 
            }//end for
        }//end fucniton





        #region ColorFullMonths
        static void RainFallColorfulDays() {
            //variables
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkGray, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen };
            double[] monthlyRain;
            double avgRainfall = 0;
            double totalRain = 0;
            int years = 0;
            int t = 0;
            //input
            years = PromptInt("How many years will we be tracking rainfall?: ");
            Console.WriteLine();
            monthlyRain = new double[years * 12];
            ///for
            for (int y = 0; y < years; y++) {
                for (int m = 0; m < 12; m++) {
                    //input
                    monthlyRain[t] = ColorTextDoulbe($"What was rain in month {months[m]}: ", colors[m]);
                    totalRain += monthlyRain[t++];
                    Console.WriteLine();
                }//end month for loop
            }//end  year for loop
            avgRainfall = totalRain / (years * 12);
            Console.WriteLine($"The average monthly rainfall for {years} years was {avgRainfall}\nTotal Rain Fall {totalRain}");
        }//end fucnton

        #endregion



        #region COLOR TEXT, INT, DOUBLE 

        static string ColorText(string message, ConsoleColor color) {
            string value = "";
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
            value = Console.ReadLine();
            //return
            return value;
        }//end funciton


        static int ColorTextInt(string messege, ConsoleColor color) {
            int value = 0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = int.Parse(Console.ReadLine());
            //return
            return value;

        }//end funciton


        static double ColorTextDoulbe(string messege, ConsoleColor color) {
            double value = 0.0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = double.Parse(Console.ReadLine());
            //return
            return value;
        }//end funciton

        #endregion



        #region COLORFUL DAYS
        static void ColorfulDays() {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.White };
            //for loop output
            for (int i = 0; i < days.Length; i++) {
                ColorText(days[i], colors[i]);
            }//end for
            #region USLESS TEXT
            /*
            //ouput like for but expanded
            ColorText(days[0], colors[0]);
            ColorText(days[1], colors[1]);
            ColorText(days[2], colors[2]);
            ColorText(days[3], colors[3]);
            ColorText(days[4], colors[4]);
            ColorText(days[5], colors[5]);
            ColorText(days[6], colors[6]);
            */
            /*
            //output but all writen out for show
            Console.Write("In my mind, ");
            ColorText(days[0], ConsoleColor.Blue, false);
            Console.WriteLine(" is always blue.");
            ColorText($"{days[1]} are brown for Taco {days[1]}s", ConsoleColor.DarkYellow);
            ColorText($"Red is the color of {days[2]}", ConsoleColor.Red);
            ColorText($"And {days[3]} is definitely green!", ConsoleColor.Green);
            ColorText($"{days[4]} is the last day of the work-week, so it's purple", ConsoleColor.Magenta);
            Console.BackgroundColor = ConsoleColor.White;
            ColorText($" And {days[5]}s are black", ConsoleColor.Black);
            Console.BackgroundColor = ConsoleColor.Black;
            ColorText($"Finally, {days[6]} are while because fuck you, I said so." , ConsoleColor.White);
            */
            #endregion
        }//end funciton
        #endregion



        #region TRY FUNCITON 
        // biging funciton int try
        static int PromptIntTry(string dataRequest) {

            //variabels
            int userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion int




        // biging funciton dulbe try
        static double PromptDoulbeTry(string dataRequest) {

            //variabels
            double userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = double.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion doulbe tyr
        #endregion  



        #region PROMPT FUNCTIONS

        //begin funstion string
        static string Prompt(string dataRequest) {

            //color
            //Console.ForegroundColor = ConsoleColor.Cyan;

            //variables
            string userInput = "";

            //request information from user
            Console.Write(dataRequest);

            //recive respones
            userInput = Console.ReadLine();

            //return
            return userInput;

        }//end funtion



        // biging funciton int
        static int PromptInt(string dataRequest) {

            //variabels
            int userInput = 0;

            //input
            userInput = int.Parse(Prompt(dataRequest));

            //return
            return userInput;

        }// end funtion int



        //regin funtion double
        static double PromptDouble(string dataRequest) {

            //variables 
            double userInput = 0.0;

            //input
            userInput = double.Parse(Prompt(dataRequest));

            //return
            return userInput;
        }// end funciton double 

        #endregion



    }//end class
}//end namespace
