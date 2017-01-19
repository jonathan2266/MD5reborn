using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn
{
    public class WordGenerator
    {
        private List<int> listOfNumbers = new List<int>();
        string text;
        linker l = new linker();
        public WordGenerator(string wordToStartFrom)
        {
            text = wordToStartFrom;
            if (wordToStartFrom == "")
            {
                listOfNumbers.Add(0);
            }
            else
            {
                convertToNumbers(wordToStartFrom);
            }
        }
        public void Next()
        {
            listOfNumbers[0] += 1;
            checkOverflow();
            transLateToLetters();
        }

        private void checkOverflow()
        {
            bool overflowFound = false;
            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] == 64)
                {
                    overflowFound = true;
                    listOfNumbers[i] = 1;
                    //check if can carry
                    if (i + 1 < listOfNumbers.Count) //space to carry
                    {
                        listOfNumbers[i + 1] += 1;
                    }
                    else
                    {
                        listOfNumbers.Add(1);
                    }
                }
            }

            if (overflowFound)
            {
                checkOverflow();
            }
        }

        public string GetCurrentWord()
        {
            return text;
        }
        private void transLateToLetters()
        {
            int[] reversed = new int[listOfNumbers.Count];
            StringBuilder builder = new StringBuilder();
            listOfNumbers.CopyTo(reversed);
            Array.Reverse(reversed);

            for (int i = 0; i < reversed.Length; i++)
            {
                builder.Append(l.NumberToString(reversed[i]));
            }
            text = Convert.ToString(builder);
        }
        private void convertToNumbers(string lastEntry)
        {
            char[] entry;
            entry = lastEntry.ToCharArray();
            for (int i = 0; i < entry.Length; i++)
            {
                listOfNumbers.Add(l.StringToNumber(entry[i]));

            }
            listOfNumbers.Reverse();
        }
    }

    class linker
    {
        private int indexLenght = 64;
        public int IndexLenght { get { return indexLenght; } }
        public string NumberToString(int i)
        {
            switch (i)
            {
                case 1:
                    return ("a");

                case 2:
                    return ("b");

                case 3:
                    return ("c");

                case 4:
                    return ("d");

                case 5:
                    return ("e");

                case 6:
                    return ("f");

                case 7:
                    return ("g");

                case 8:
                    return ("h");

                case 9:
                    return ("i");

                case 10:
                    return ("j");

                case 11:
                    return ("k");

                case 12:
                    return ("l");

                case 13:
                    return ("m");

                case 14:
                    return ("n");

                case 15:
                    return ("o");

                case 16:
                    return ("p");

                case 17:
                    return ("q");

                case 18:
                    return ("r");

                case 19:
                    return ("s");

                case 20:
                    return ("t");

                case 21:
                    return ("u");

                case 22:
                    return ("v");

                case 23:
                    return ("w");

                case 24:
                    return ("x");

                case 25:
                    return ("y");

                case 26:
                    return ("z");

                case 27:
                    return ("A");

                case 28:
                    return ("B");

                case 29:
                    return ("C");

                case 30:
                    return ("D");

                case 31:
                    return ("E");

                case 32:
                    return ("F");

                case 33:
                    return ("G");

                case 34:
                    return ("H");

                case 35:
                    return ("I");

                case 36:
                    return ("J");

                case 37:
                    return ("K");

                case 38:
                    return ("L");

                case 39:
                    return ("M");

                case 40:
                    return ("N");

                case 41:
                    return ("O");

                case 42:
                    return ("P");

                case 43:
                    return ("Q");

                case 44:
                    return ("R");

                case 45:
                    return ("S");

                case 46:
                    return ("T");

                case 47:
                    return ("U");

                case 48:
                    return ("V");

                case 49:
                    return ("W");

                case 50:
                    return ("X");

                case 51:
                    return ("Y");

                case 52:
                    return ("Z");

                case 53:
                    return (" ");

                case 54:
                    return ("0");

                case 55:
                    return ("1");

                case 56:
                    return ("2");

                case 57:
                    return ("3");

                case 58:
                    return ("4");

                case 59:
                    return ("5");

                case 60:
                    return ("6");

                case 61:
                    return ("7");

                case 62:
                    return ("8");

                case 63:
                    return ("9");

                default:
                    return ("");
            }
        }
        public int StringToNumber(char letter)
        {

            int temp = 1;

            switch (letter)
            {
                case 'a':
                    temp = 1;
                    break;
                case 'b':
                    temp = 2;
                    break;
                case 'c':
                    temp = 3;
                    break;
                case 'd':
                    temp = 4;
                    break;
                case 'e':
                    temp = 5;
                    break;
                case 'f':
                    temp = 6;
                    break;
                case 'g':
                    temp = 7;
                    break;
                case 'h':
                    temp = 8;
                    break;
                case 'i':
                    temp = 9;
                    break;
                case 'j':
                    temp = 10;
                    break;
                case 'k':
                    temp = 11;
                    break;
                case 'l':
                    temp = 12;
                    break;
                case 'm':
                    temp = 13;
                    break;
                case 'n':
                    temp = 14;
                    break;
                case 'o':
                    temp = 15;
                    break;
                case 'p':
                    temp = 16;
                    break;
                case 'q':
                    temp = 17;
                    break;
                case 'r':
                    temp = 18;
                    break;
                case 's':
                    temp = 19;
                    break;
                case 't':
                    temp = 20;
                    break;
                case 'u':
                    temp = 21;
                    break;
                case 'v':
                    temp = 22;
                    break;
                case 'w':
                    temp = 23;
                    break;
                case 'x':
                    temp = 24;
                    break;
                case 'y':
                    temp = 25;
                    break;
                case 'z':
                    temp = 26;
                    break;
                case 'A':
                    temp = 27;
                    break;
                case 'B':
                    temp = 28;
                    break;
                case 'C':
                    temp = 29;
                    break;
                case 'D':
                    temp = 30;
                    break;
                case 'E':
                    temp = 31;
                    break;
                case 'F':
                    temp = 32;
                    break;
                case 'G':
                    temp = 33;
                    break;
                case 'H':
                    temp = 34;
                    break;
                case 'I':
                    temp = 35;
                    break;
                case 'J':
                    temp = 36;
                    break;
                case 'K':
                    temp = 37;
                    break;
                case 'L':
                    temp = 38;
                    break;
                case 'M':
                    temp = 39;
                    break;
                case 'N':
                    temp = 40;
                    break;
                case 'O':
                    temp = 41;
                    break;
                case 'P':
                    temp = 42;
                    break;
                case 'Q':
                    temp = 43;
                    break;
                case 'R':
                    temp = 44;
                    break;
                case 'S':
                    temp = 45;
                    break;
                case 'T':
                    temp = 46;
                    break;
                case 'U':
                    temp = 47;
                    break;
                case 'V':
                    temp = 48;
                    break;
                case 'W':
                    temp = 49;
                    break;
                case 'X':
                    temp = 50;
                    break;
                case 'Y':
                    temp = 51;
                    break;
                case 'Z':
                    temp = 52;
                    break;
                case ' ':
                    temp = 53;
                    break;
                case '0':
                    temp = 54;
                    break;
                case '1':
                    temp = 55;
                    break;
                case '2':
                    temp = 56;
                    break;
                case '3':
                    temp = 57;
                    break;
                case '4':
                    temp = 58;
                    break;
                case '5':
                    temp = 59;
                    break;
                case '6':
                    temp = 60;
                    break;
                case '7':
                    temp = 61;
                    break;
                case '8':
                    temp = 62;
                    break;
                case '9':
                    temp = 63;
                    break;
                default:
                    temp = 0;
                    break;
            }
            return temp;
        }
    }
}
