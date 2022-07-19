/*

Steven Richmond
CSCD371 - .NET Programming
Final Project - Animated Sorting (REVISED)

This program is a graphical user interface application that visually represents what a few different sorting algorithms do to arrange data into order.
I have used Selection Sort, Insertion Sort, and Bubble Sort. FYI, I referenced Wikipedia for the sorting algorithms.
As per the instructiions, the initial numbers (I chose a size of 10 for simplicity sake) are generated either randomly, in ascending order
(which makes no sense, since that's what sorting is going to do), and descending order.

Thank you for letting me revise. I learned so much more about WPF and C# and all the different methods that can be used to animate onjects.
I opted for DoubleAnimation, as using a Timer seemed sloppy, and using a Storyboard seemed overkill. Setting up asychronous tasks and awaits was fun.
 
*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimatedSorting5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<int> numbers = new List<int>(10);
        List<TextBlock> listOfTextBlocks;

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            numbers.Clear();

            //RANDOM
            if (ArrangementSelection.Text == "Random")
            {
                Random r = new Random();

                numbers = new List<int>(10);

                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(r.Next(1, 99));
                }

                UpdateNumbers();

                ApplySortButton.IsEnabled = true;
            }

            //ASCENDING
            if (ArrangementSelection.Text == "Ascending")
            {
                numbers.Clear();

                Random r = new Random();

                numbers = new List<int>(10);

                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(r.Next(1, 99));
                }

                numbers.Sort();

                UpdateNumbers();

                ApplySortButton.IsEnabled = true;
            }

            //DESCENDING
            if (ArrangementSelection.Text == "Descending")
            {
                numbers.Clear();

                Random r = new Random();

                numbers = new List<int>(10);

                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(r.Next(1, 99));
                }

                numbers.Sort();
                numbers.Reverse();

                UpdateNumbers();

                ApplySortButton.IsEnabled = true;
            }

        }

        private void UpdateNumbers()
        {
            Number0.Text = numbers[0].ToString();
            Number1.Text = numbers[1].ToString();
            Number2.Text = numbers[2].ToString();
            Number3.Text = numbers[3].ToString();
            Number4.Text = numbers[4].ToString();
            Number5.Text = numbers[5].ToString();
            Number6.Text = numbers[6].ToString();
            Number7.Text = numbers[7].ToString();
            Number8.Text = numbers[8].ToString();
            Number9.Text = numbers[9].ToString();

            listOfTextBlocks = new List<TextBlock>(10);

            listOfTextBlocks.Add(Number0);
            listOfTextBlocks.Add(Number1);
            listOfTextBlocks.Add(Number2);
            listOfTextBlocks.Add(Number3);
            listOfTextBlocks.Add(Number4);
            listOfTextBlocks.Add(Number5);
            listOfTextBlocks.Add(Number6);
            listOfTextBlocks.Add(Number7);
            listOfTextBlocks.Add(Number8);
            listOfTextBlocks.Add(Number9);
        }

        private void Reset()
        {
            //foreach (TextBlock tb in AnimationCanvas)
            //{
            //    tb.BeginAnimation(Canvas.LeftProperty, null);
            //    tb.BeginAnimation(Canvas.TopProperty, null);
            //}

            Number0.BeginAnimation(Canvas.LeftProperty, null);
            Number1.BeginAnimation(Canvas.LeftProperty, null);
            Number2.BeginAnimation(Canvas.LeftProperty, null);
            Number3.BeginAnimation(Canvas.LeftProperty, null);
            Number4.BeginAnimation(Canvas.LeftProperty, null);
            Number5.BeginAnimation(Canvas.LeftProperty, null);
            Number6.BeginAnimation(Canvas.LeftProperty, null);
            Number7.BeginAnimation(Canvas.LeftProperty, null);
            Number8.BeginAnimation(Canvas.LeftProperty, null);
            Number9.BeginAnimation(Canvas.LeftProperty, null);
            Number0.BeginAnimation(Canvas.TopProperty, null);
            Number1.BeginAnimation(Canvas.TopProperty, null);
            Number2.BeginAnimation(Canvas.TopProperty, null);
            Number3.BeginAnimation(Canvas.TopProperty, null);
            Number4.BeginAnimation(Canvas.TopProperty, null);
            Number5.BeginAnimation(Canvas.TopProperty, null);
            Number6.BeginAnimation(Canvas.TopProperty, null);
            Number7.BeginAnimation(Canvas.TopProperty, null);
            Number8.BeginAnimation(Canvas.TopProperty, null);
            Number9.BeginAnimation(Canvas.TopProperty, null);

            Canvas.SetLeft(Number0, 50);
            Canvas.SetLeft(Number1, 125);
            Canvas.SetLeft(Number2, 200);
            Canvas.SetLeft(Number3, 275);
            Canvas.SetLeft(Number4, 350);
            Canvas.SetLeft(Number5, 425);
            Canvas.SetLeft(Number6, 500);
            Canvas.SetLeft(Number7, 575);
            Canvas.SetLeft(Number8, 650);
            Canvas.SetLeft(Number9, 725);
            Canvas.SetTop(Number0, 150);
            Canvas.SetTop(Number1, 150);
            Canvas.SetTop(Number2, 150);
            Canvas.SetTop(Number3, 150);
            Canvas.SetTop(Number4, 150);
            Canvas.SetTop(Number5, 150);
            Canvas.SetTop(Number6, 150);
            Canvas.SetTop(Number7, 150);
            Canvas.SetTop(Number8, 150);
            Canvas.SetTop(Number9, 150);

            Number0.Text = "-";
            Number1.Text = "G";
            Number2.Text = "E";
            Number3.Text = "N";
            Number4.Text = "E";
            Number5.Text = "R";
            Number6.Text = "A";
            Number7.Text = "T";
            Number8.Text = "E";
            Number9.Text = "-";

            Number0.Foreground = Brushes.White;
            Number1.Foreground = Brushes.White;
            Number2.Foreground = Brushes.White;
            Number3.Foreground = Brushes.White;
            Number4.Foreground = Brushes.White;
            Number5.Foreground = Brushes.White;
            Number6.Foreground = Brushes.White;
            Number7.Foreground = Brushes.White;
            Number8.Foreground = Brushes.White;
            Number9.Foreground = Brushes.White;


            GenerateButton.IsEnabled = true;

        }

        private void ApplySortButton_Click(object sender, RoutedEventArgs e)
        {
            if (SortingRoutineSelection.Text == "Insertion Sort")
            {
                InsertionSort();
            }

            if (SortingRoutineSelection.Text == "Selection Sort")
            {
                SelectionSort();
            }

            if (SortingRoutineSelection.Text == "Bubble Sort")
            {
                BubbleSort();
            }
        }

        private async void SelectionSort()
        {
            /*
            string list = "";
            foreach (int i in numbers)
            {
                list += i.ToString() + ", ";
            }
            MessageBox.Show(list);
            */

            ApplySortButton.IsEnabled = false;
            GenerateButton.IsEnabled = false;

            int current_min, temp;

            for (int i = 0; i < 10; i++)
            {
                current_min = i;

                for (int j = i + 1; j < 10; j++)
                {
                    if (numbers[j] < numbers[current_min])
                    {
                        current_min = j;
                    }
                }

                if (current_min != i)
                {

                    TextBlock curMin = listOfTextBlocks[current_min];
                    TextBlock newMin = listOfTextBlocks[i];

                    moveUp(curMin);
                    moveDown(newMin);
                    await Task.Delay(1000);

                    int indexDiff = current_min - i;
                    for (int z = 0; z < indexDiff; z++)
                    {
                        moveLeft(curMin);
                        moveRight(newMin);
                        await Task.Delay(1000);
                    }

                    moveDown(curMin);
                    moveUp(newMin);
                    await Task.Delay(1000);

                    curMin.Foreground = Brushes.Black;

                    temp = numbers[i];
                    numbers[i] = numbers[current_min];
                    numbers[current_min] = temp;

                    TextBlock tempTB = listOfTextBlocks[i];
                    listOfTextBlocks[i] = listOfTextBlocks[current_min];
                    listOfTextBlocks[current_min] = tempTB;
                }
            }

            MessageBox.Show("Click OK to Reset");
            Reset();
        }

        private async void InsertionSort()
        {

            ApplySortButton.IsEnabled = false;
            GenerateButton.IsEnabled = false;

            for (int i = 1; i < numbers.Count; ++i)
            {
                int key = numbers[i];

                int j = i - 1;

                if (j >= 0 && numbers[j] > key)
                {
                    TextBlock lower = listOfTextBlocks[j + 1];
                    moveDown(lower);
                    await Task.Delay(1000);

                    while (j >= 0 && numbers[j] > key)
                    {
                        TextBlock next = listOfTextBlocks[j];

                        int temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;


                        TextBlock tempTB = listOfTextBlocks[j + 1];
                        listOfTextBlocks[j + 1] = listOfTextBlocks[j];
                        listOfTextBlocks[j] = tempTB;

                        moveLeft(lower);
                        moveRight(next);
                        await Task.Delay(1000);


                        j = j - 1;
                    }

                    moveUp(lower);
                    await Task.Delay(1000);
                }

                numbers[j + 1] = key;

            }

            MessageBox.Show("Click OK to reset");
            Reset();
        }

        private async void BubbleSort()
        {
            for (int i = 0; i <= numbers.Count - 2; i++)
            {
                for (int j = 0; j <= numbers.Count - 2; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        moveLeft(listOfTextBlocks[j + 1]);
                        moveRight(listOfTextBlocks[j]);
                        await Task.Delay(1000);

                        int temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;

                        TextBlock tempTB = listOfTextBlocks[j + 1];
                        listOfTextBlocks[j + 1] = listOfTextBlocks[j];
                        listOfTextBlocks[j] = tempTB;

                    }
                }
            }
            MessageBox.Show("Click OK to reset");
            Reset();
        }

        DoubleAnimation da;
        private void moveUp(TextBlock tb)
        {
            da = new DoubleAnimation();
            da.From = Canvas.GetTop(tb);
            da.To = Canvas.GetTop(tb) - 75;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            tb.BeginAnimation(Canvas.TopProperty, da);

        }

        private void moveDown(TextBlock tb)
        {
            da = new DoubleAnimation();
            da.From = Canvas.GetTop(tb);
            da.To = Canvas.GetTop(tb) + 75;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            tb.BeginAnimation(Canvas.TopProperty, da);

        }
        private void moveLeft(TextBlock tb)
        {
            da = new DoubleAnimation();
            da.From = Canvas.GetLeft(tb);
            da.To = Canvas.GetLeft(tb) - 75;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            tb.BeginAnimation(Canvas.LeftProperty, da);

        }

        private void moveRight(TextBlock tb)
        {
            da = new DoubleAnimation();
            da.From = Canvas.GetLeft(tb);
            da.To = Canvas.GetLeft(tb) + 75;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            tb.BeginAnimation(Canvas.LeftProperty, da);

        }
    }
}
