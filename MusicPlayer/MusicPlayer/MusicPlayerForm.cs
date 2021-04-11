/*
 * You have been hired as the new programmer by the Jupiter Mining Corporation
 * to produce a test program for the company,
 * this program will be fully documented and tested.
 * With this project you are coming up with a program to show your range of skills
 * and abilities to your new boss.
 * You have been given an example of what your boss is expecting to see
 * The example they have given is an advanced music player
 * that allows the ability to sort and search the songs stored in a binary tree
 * (any sort and search algorithm you select will have to be approved
 * if it is not merge sort and binary search),
 * the GUI should display the sorted track list and highlight and play the searched track,
 * it should save the track list to a csv using a 3rd party library.
 * The music player must load and play files and met the requirements laid out in Question 3.
 * If you choose not to implement this project
 * you must negotiate a project of equal complexity that meets the requirements in Question 3.
 * Third party library link - https://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader
 * Jose Rico Imbang
 * 30019932
 * 26/11/2020
 * AT3 - Project
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;

namespace MusicPlayer
{
    public partial class MusicPlayerForm : Form
    {
        private string FileName;
        private AvlTree songTree = new AvlTree();

        public MusicPlayerForm()
        {
            InitializeComponent();
        }

        // Clear the TextBox
        private void ResetInformation()
        {
            TBInformation.Clear();
        }

        // Play an audio
        private void Play(string song)
        {
            AxWindowsMediaPlayer.URL = song;
            //ResetInformation();
        }

        private void GetListBoxItems()
        {

            int nSongs = LBSongs.Items.Count;
            string[] songs = new string[nSongs];

            for (int i = 0; i < nSongs; i++)
            {
                songs[i] = LBSongs.Items[i].ToString();
            }

            MergeSort(songs, 0, nSongs - 1);
            LBSongs.Items.Clear();
            Display(songs);

            /*
            List<string> songs = new List<string>();

            foreach (object item in LBSongs.Items)
            {
                songs.Add(item.ToString());
            }
            MergeSort(songs, 0, songs.Count - 1);
            */
        }

        #region ****************************SORT ALGORITHM****************************
        private void Merge<T>(T[] values, int left, int mid, int right) where T : IComparable<T>
        {
            T[] temp = new T[25];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (values[left].CompareTo(values[mid]) < 0)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
                temp[pos++] = values[left++];

            while (mid <= right)
                temp[pos++] = values[mid++];

            for (i = 0; i < num; i++)
            {
                values[right] = temp[right];
                right--;
            }
        }

        private void MergeSort<T>(T[] values, int left, int right) where T : IComparable<T>
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(values, left, mid);
                MergeSort(values, (mid + 1), right);

                Merge(values, left, (mid + 1), right);
            }
        }
        #endregion

        private void Display(string[] songs)
        {
            for (int i = 0; i < songs.Length; i++)
            {
                LBSongs.Items.Add(songs[i]);
            }
        }

        #region ****************************THIRD-PARTY LIBRARY****************************
        // Add songs
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileName = fd.FileName;
            }

            using (CsvReader csvReader = new CsvReader(new StreamReader(FileName), true))
            {
                string[] headers = csvReader.GetFieldHeaders();

                for (int i = 0; i < headers.Length; i++)
                {
                    songTree.Add(headers[i]);
                }
                songTree.DisplaySongs(LBSongs, TBInformation);
            }
        }
        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string temp = Path.GetDirectoryName(FileName) + "\\";
            string fullPath = songTree.Find(temp + TBSearch.Text + ".mp3");
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);
            if (fullPath.Equals("empty"))
                TBInformation.Text = fullPath;
            else if (fullPath.Equals("not found"))
                TBInformation.Text = fullPath;
            else
            {
                LBSongs.SelectedItem = fileNameWithoutExtension;
                Play(fullPath);
            }
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            GetListBoxItems();
        }
    }
}
