using System;

namespace Array2D
{
    class Array2D
    {
        int rowsize = 6;         // rowsize=overall size of row, colsize=overall size of col  
        int colsize = 6;
        int i, j, logrow, logcol; // logrow=logical size of row, logcol=logical size of column
        int[,] arr = new int[10, 10];
        int[,] arr2 = new int[10, 10];
        int[,] arr3 = new int[10, 10];
        int[,] result = new int[10, 10];
        int choice;
       // Boolean issymmetric = true, isdiagonal = true,flag=true;
        int phyrow = 5, phycol = 5;
        public void Menu()    //Method of menu
        {
            int n;
            Console.WriteLine("Select option no: \n\t 1: Create \n\t 2: Insert \n\t 3: Output \n\t" +
                "4: Delete \n\t5: Update \n\t 6: Rotate \n\t 7: Operations \n\t 8: Statistics");
            n = Convert.ToInt16(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("You selected to Create");
                    Create();
                    again();
                    break;
                case 2:
                    Console.WriteLine("You selected Insert");
                    Insert();
                    again();
                    break;
                case 3:
                    Output();
                    again();
                    break;
                case 4:
                    Console.WriteLine("You selected Delete");
                    Delete();
                    again();
                    break;
                case 5:
                    Console.WriteLine("You selected Update");
                    Update();
                    again();
                    break;
                case 6:
                    Console.WriteLine("You selected Rotate");
                    Rotate();
                    again();
                    break;

                case 7:
                    Console.WriteLine("You selected Operations");
                    Operations();
                    again();
                    break;
                case 8:
                    Console.WriteLine("You selected Statistics");
                    Statistics();
                    again();
                    break;

                            

            }

        }
        public void Create()    //Method to create array
        {

            Console.WriteLine("How many rows you want to create in 2D array??");
            logrow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many columns you want to create in 2D array??");
            logcol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements");

            if (logrow >= rowsize && logcol >= colsize)
            { Console.WriteLine("Out of range"); }
            else
            {
                for (i = 1; i <= logrow; i++)
                {
                    for (j = 1; j <= logcol; j++)
                    {
                        arr[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }


                print();
            }
            Console.ReadLine();
        }
        public void Statistics()
        {
            
                Console.WriteLine("No. of rows: " + logrow);
                Console.WriteLine("No. of rows: " + logcol);
                if (Symmetrical()== true)
                {
                    Console.WriteLine("Symmetric Matrix:yes");

                    }
                else
                {
                    Console.WriteLine("Symmetric Matrix:No");

                }
            if (Diagonal() == true)
            {
                Console.WriteLine("Diagonal Matrix:yes");

            }
            else
            {
                Console.WriteLine("Diagonal Matrix:No");

            }
            if (Identity() == true)
            {
                Console.WriteLine("Identity Matrix:yes");

            }
            else
            {
                Console.WriteLine("Identity Matrix:No");

            }

        }

        
        public void Insert() //Method to insert elements in array
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                int choice;
                Console.WriteLine("You want to Insert elements at \n\t 1.Row? \n\t 2.Column? ");
                choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter row number on which you want to insert record ? ");
                    int rownum = int.Parse(Console.ReadLine());
                    logrow++;
                    for (i = logrow; i >= rownum; i--)
                    {
                        for (j = 1; j <= logcol; j++)

                        {
                            arr[i + 1, j] = arr[i, j];

                        }
                    }
                    Console.WriteLine("Enter elements");
                    for (i = rownum, j = 1; j <= logcol; j++)
                    {
                        arr[i, j] = Convert.ToInt32(Console.ReadLine());
                        arr[i, j] = arr[i, j];
                    }
                    print();
                }




                else if (choice == 2)
                {
                    Console.WriteLine("Enter column number on which you want to insert record ? ");
                    int colnum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter elements");
                    for (i = colnum; i <= rowsize; i++) // insertion at specific column
                    {
                        arr[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Printing Matrix: ");      //print array after insertion 

                    for (i = 1; i <= phyrow; i++)
                    {
                        for (j = 1; j <= phycol; j++)
                        {
                            Console.Write(arr[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }

                }
                else
                    Console.WriteLine("You enetered invalid options ");

            }
            else if (logrow > phyrow || logcol > phycol)
            {
                Console.WriteLine("Limit is reached");

            }
            Console.ReadLine();

        }


        

        public void Update() //method of update rows or columns in matrix
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                int upchoice; // upchoice = choice for update 
                Console.WriteLine("You want to update elements at \n\t 1.Row? \n\t 2.Column? ");
                upchoice = Convert.ToInt16(Console.ReadLine());
                if (upchoice == 1)
                {
                    int posRow; //posRow= Row number or Row position
                    Console.WriteLine("Enter Row number on which you want to update the record: ");
                    posRow = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter elements you want to update at row {0}", posRow);
                    for (i = 1; i <= logrow; i++)
                    {
                        for (j = 1; j <= logcol; j++)
                        {
                            if (i < posRow)
                            {
                                arr[i, j] = arr[i, j];
                            }
                            else if (i == posRow)
                            {
                                arr[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                arr[i, j] = arr[i, j];
                            }
                        }
                    }

                    print();
                    
                }
                else if (upchoice == 2)
                {
                    int posCol; //pos Column=Column number or Column position
                    Console.WriteLine("Enter Column number on which you want to update the record: ");
                    posCol = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter elements you want to update at column {0}", posCol);
                    for (j = 1; j <= logcol; j++)
                    {
                        for (i = 1; i <= logrow; i++)
                        {
                            if (j < posCol)
                            {
                                arr[i, j] = arr[i, j];
                            }
                            else if (j == posCol)
                            {
                                arr[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                arr[i, j] = arr[i, j];
                            }
                        }
                    }

                    print();
                    
                    
                }
            }
            Console.ReadKey();
        }
        public void Delete() //method of delete rows or columns in matrix
        {
            check();
            if (logrow >= 0 && logcol >= 0)
               
            {
               
                int dechoice; // dechoice = choice for delete 
                Console.WriteLine("You want to delete elements at \n\t 1.Row? \n\t 2.Column? ");
                dechoice = Convert.ToInt16(Console.ReadLine());
                if (dechoice == 1)
                {
                    int Rowpos; //posRow= Row number or Row position
                    Console.WriteLine("Enter Row number on which you want to delete the record: ");
                    Rowpos = Convert.ToInt16(Console.ReadLine());
                    if (Rowpos > rowsize)
                    {
                        Console.WriteLine("Deletion isn't possible");
                    }
                    else
                    {
                        for (i = 1; i <= logrow; i++)
                        {
                            for (j = 1; j <= logcol; j++)
                            {
                                if (i < Rowpos)
                                {
                                    arr[i, j] = arr[i, j];
                                }
                                else
                                {
                                    arr[i, j] = arr[i + 1, j];
                                }
                            }
                        }

                        print();
                        logrow = logrow - 1;
                        
                    }

                }
                else if (dechoice == 2)
                {
                    int Colpos; //pos Column=Column number or Column position
                    Console.WriteLine("Enter Column number on which you want to delete the record: ");
                    Colpos = Convert.ToInt16(Console.ReadLine());
                    if (Colpos > colsize)
                    {
                        Console.WriteLine("Deletion isn't possible");
                    }
                    else
                    {
                        for (j = 1; j <= logcol; j++)
                        {
                            for (i = 1; i <= logrow; i++)
                            {
                                if (j < Colpos)
                                {
                                    arr[i, j] = arr[i, j];
                                }
                                else
                                {
                                    arr[i, j] = arr[i, j + 1];
                                }
                            }
                        }

                        print();
                        logcol = logcol - 1;
                        
                    }
                }
            }
            Console.ReadKey();
        }

        public void Output() // method of traversing matrix in different ways
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                int choice, search, r = 0, c = 0, loc = 0;
                Console.WriteLine("You Choose Output");
                Console.WriteLine("You want to delete elements at \n\t 1.Element ? \n\t 2.Row ?\n\t 3.Column ?\n\t 4. Traverse Row wise?\n\t 5. Traverse Column wise? ");
                choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter Element to be searched: ");
                    search = Convert.ToInt16(Console.ReadLine());
                    for (i = 1; i <= logrow; i++)
                    {
                        for (j = 1; j <= logcol; j++)
                        {

                            if (arr[i, j] == search)
                            {
                                loc = 1;
                                r = i;
                                c = j;
                                break;
                            }


                        }

                    }
                    if (loc == 1)
                        Console.WriteLine("element{0} is found at location{1}{2}", search, r, c);

                    else
                        Console.WriteLine("Element not found");
                }


                else if (choice == 2)
                {

                    Console.WriteLine("Enter row to be searched: ");
                    search = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\nHere is your desired row: \n");
                    Console.WriteLine("Row {0}:",search);
                    for (i=search,j = 1; j <= logcol; j++)
                        {

                        Console.Write(arr[i, j]+"\t");
                    }
                    
                                        


                }
                else if (choice == 3)
                {

                    Console.WriteLine("Enter column to be searched: ");
                    search = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("\nHere is your desired column: \n");
                    Console.WriteLine("Column {0}:", search);
                    for (j = search, i = 1; i <= logrow; i++)
                    {

                        Console.Write(arr[i, j] +"\n");
                    }




                }
                else if (choice == 4)
                {
                    for (i = 1; i <= logrow; i++)
                    {
                        for (j = 1; j <= logcol; j++)
                        {
                            Console.Write("{" + arr[i, j] + "}");
                        }

                    }
                }
                else if (choice == 5)
                {
                    for (i = 1; i <= logrow; i++)
                    {
                        for (j = 1; j <= logcol; j++)
                        {
                            Console.Write("{" + arr[j, i] + "}");
                        }

                    }
                }
                else
                    Console.WriteLine("invalid option");
            }
            Console.ReadKey();
        }
        Boolean Diagonal() //method of checking if matrix is diagonal or not?
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                
                for (i = 1; i < logrow; i++)
                {
                    for (j = 1; j < logcol; j++)
                    {
                        if (i != j && arr[i, j] != 0)
                        {
                            return false;

                        }
                    }
                }
                           }
            return true;

        }

        Boolean Identity() //method of checking if matrix is identity or not?
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                
                for (i = 1; i < logrow; i++)
                {
                    for (j = 1; j < logcol; j++)
                    {
                        if ((i == j && arr[i, j] != 1) || (i != j && arr[i, j] != 0))
                        {
                            return false;

                        }
                    }
                }
                
            }
            return true;
        }
        public void Transpose() //method of getting tranpose of a matrix
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {

                for (i = 1; i <= logrow; i++)
                {
                    for (j = 1; j <= logcol; j++)
                    {
                        arr3[j, i] = arr[i, j];
                    }
                    
                }

            }
            
        }
        Boolean Symmetrical() //method of checking if matrix is symmetrical or not?
        {
            
                Transpose(); 
            

            for (i = 1; i < logrow; i++)
            {
                for (j = 1; j < logcol; j++)
                {
                    if (arr3[i, j] != arr[i, j])
                    {
                        return false;
                                       
                   }
               
                 
                }
                
            }

            
            
            return true;
            
        }


        

        public void print() // method of printing matrix
        {
            Console.WriteLine("Printing Matrix: ");
            for (i = 1; i <= logrow; i++)
            {
                for (j = 1; j <= logcol; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void check()  //method of checking if matrix is empty
        {
            if (logrow <= 0 && logcol <= 0)
            {
                Console.WriteLine("First create a 2D array");
                again();
            }

        }
        public void Rotate() //method of Rotation
        {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                int choice, temp = 0, j = logcol;
                Console.WriteLine("You want to update elements at \n\t 1.Rotate Row Right ? \n\t 2.Rotate Row Left? \n\t 3.Rotate Column Up?\n\t 4. Rotate Column Down?\n\t 5.Rotate matrix +90 ");
                choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {

                    Console.WriteLine("Enter row number you want to rotate right: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                    temp = arr[choice, logcol];
                    for (i = choice, j = logcol - 1; j >= 1; j--)
                    {
                        arr[choice, j + 1] = arr[choice, j];

                    }
                    arr[choice, 1] = temp;
                    print();
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter row number you want to rotate left: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                    temp = arr[choice, 1];
                    for (i = choice, j = 1; j <= logcol; j++)
                    {
                        arr[choice, j] = arr[choice, j + 1];

                    }
                    arr[choice, logcol] = temp;
                    print();
                    Console.ReadKey();

                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter column number you want to rotate up: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                    temp = arr[1, choice];
                    for (j = choice, i = 1; i <= logrow; i++)
                    {
                        arr[i, choice] = arr[i + 1, choice];

                    }
                    arr[logrow, choice] = temp;
                    print();
                    Console.ReadKey();

                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter column number you want to rotate down: ");
                    choice = Convert.ToInt16(Console.ReadLine());

                    temp = arr[logrow, choice];
                    for (j = choice, i = logrow - 1; i >= 1; i--)
                    {
                        arr[i + 1, choice] = arr[i, choice];

                    }
                    arr[1, choice] = temp;
                    print();
                    Console.ReadKey();

                }
                else if (choice == 5)
                {

                    if (logrow == logcol)

                    {

                        Console.WriteLine("Printing Matrix: ");
                        for (j = 1; j <= logcol; j++)
                        {
                            for (i = logrow; i >= 1; i--)
                            {
                                Console.Write(arr[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                    }
                    else { Console.WriteLine("rotation not possible"); }
                }

                else
                {
                    Console.WriteLine("invalid option");

                }
            }

            Console.ReadKey();
        }
        


        public void Operations() // method of multiple operations on matrix
         {
            check();
            if (logrow >= 0 && logcol >= 0)
            {
                Console.WriteLine("Which operation do you want to perform?");
                Console.WriteLine("\t1.Addition \n\t2.Subtraction \n\t3.Multiplication ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many rows you want to create in second matrix?\n");
                int row2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many columns you want to create in second matrix?\n");
                int col2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter elements in the second matrix :\n");
                for (i = 1; i <= row2; i++)
                {
                    for (j = 1; j <= col2; j++)
                    {

                        arr2[i, j] = Convert.ToInt32(Console.ReadLine());

                    }
                }
                Console.WriteLine("Printing Matrix: ");
                for (i = 1; i <= row2; i++)
                {
                    for (j = 1; j <= col2; j++)
                    {
                        Console.Write(arr2[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                switch (choice)
                {
                    case 1:
                        if (logrow == row2 && logcol == col2)
                        {
                            for (i = 1; i <= logrow; i++)
                            {
                                for (j = 1; j <= logcol; j++)
                                {
                                    result[i, j] = (arr[i, j] + arr2[i, j]);
                                }
                            }
                            printResult();

                        }
                        else
                        {

                            Console.WriteLine("Addition not possible");
                            Console.Write("\nSize of both matrices must be same\n");
                        }

                        break;
                    case 2:
                        if (logrow == row2 && logcol == col2)
                        {
                            for (i = 1; i <= logrow; i++)
                            {
                                for (j = 1; j <= logcol; j++)
                                {
                                    result[i, j] = (arr[i, j] - arr2[i, j]);
                                }
                            }
                            printResult();

                        }
                        else
                        {

                            Console.WriteLine("Subtraction not possible");
                            Console.Write("\nSize of both matrices must be same\n");

                        }
                        break;
                    case 3:
                        if (logcol != row2)
                        {
                            Console.Write("Mutiplication of Matrix is not possible\n");
                            Console.Write("\nColumn of first matrix and row of second matrix must be same\n");
                        }

                        else
                        {
                            Console.WriteLine("Matrix Multiplication is :\n");
                            for (i = 1; i <= logrow; i++)
                            {
                                for (j = 1; j <= col2; j++)
                                {
                                    for (int k = 1; k <= row2; k++)
                                    {
                                        result[i, j] += arr[i, k] * arr2[k, j];
                                    }
                                }
                            }
                            for (i = 1; i <= logrow; i++)
                            {
                                for (j = 1; j <= col2; j++)
                                {
                                    Console.Write(result[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;

                }
            }
            Console.ReadKey(); 
        }
        public void printResult() // method of priniting resultant matrix after multiplying two matrices
        {
            Console.WriteLine("\nResultant Matrix is :\n");

            for (i = 1; i <= logrow; i++)
            {
                for (j = 1; j <= logcol; j++)
                {
                    Console.Write(result[i, j] + " \t");
                }
                Console.WriteLine();
            }
        }
        public int again()  //Method of again go to menu
        {
            int k;
            Console.WriteLine("you want to go back to main menu?\n\t 1.Yes 2.No ");
            k = Convert.ToInt32(Console.ReadLine());
            if (k == 1)
                Menu();
            else if (k == 2)
                return 0;
            else Console.WriteLine("Incorrect command");
            return 1;
        }


    }
}





































































