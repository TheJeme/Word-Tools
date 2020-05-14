using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WordTools
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string[] ignoredCharacters = { ",", ".", " ", "-", "'" };

        async void InfoButton_Clicked(object sender, EventArgs e)
        {
            if (wordsText.Text.Length > 0)
            {
                IDictionary<string, int> wordList = new Dictionary<string, int>();
                string[] words = wordsText.Text.Split();

                foreach (var i in words)
                {
                    if (wordList.ContainsKey(i))
                    {
                        wordList[i] += 1;
                    }
                    else
                    {
                        if (ignoredCharacters.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            wordList.Add(i, 1);
                        }
                    }
                }

                var sortedWordList = wordList.OrderByDescending(x => x.Value);

                string displayWords = "";

                for (int i=0; i < sortedWordList.Count(); i++)
                {
                    displayWords += $"{i+1}. {sortedWordList.ElementAt(i).Key} - {sortedWordList.ElementAt(i).Value} \n";
                    if (i == 9)
                    {
                        break;
                    }
                }

                await DisplayAlert("Keyword Density", displayWords, "OK");
            }
            else
            {
                await DisplayAlert("Keyword Density", "List is empty", "OK");
            }
            
        }

        private void WordsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int wordCount = 0;
            int charCount = 0;


            
            charCount = wordsText.Text.Length;

            if (wordsText.Text == "")
            {
                wordCount = 0;
            }
            else
            {
                wordCount = wordsText.Text.Split().Length;
            }

            WordLabel.Text = $"Words: {wordCount}";
            CharLabel.Text = $"Words: {charCount}";
        }
    }
}
