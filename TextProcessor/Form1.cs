﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TextProcessor
{
    public partial class MainForm : Form
    {

        private static string filePath = Path.Combine(FoldCreator(), "ProcessedText.txt");

        public MainForm()
        {
            InitializeComponent();
            btnProcessText.Click += new EventHandler(BtnProcessText_Click);
            btnSelectFolder.Click += new EventHandler(BtnSelectFolder_Click);
            btnClearFolder.Click += new EventHandler(BtnClearFolder_Click);

        }

        // Создание папки для вывода ".тхт" файла
        private static string FoldCreator()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TextProcessorFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        private void BtnProcessText_Click(object sender, EventArgs e)
        {

            string inputText = txtInput.Text;

            // Попытка прочитать дату. Если это не дата, программа попытается обработать эту строку, как стандартный текст
            if (DateTime.TryParseExact(inputText, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                txtResult.Clear();
                txtResult.Text = $"\nДата в формате 'дд-мм-гггг': {date:dd-MM-yyyy}" +
                                 $"\n День недели: {date.DayOfWeek}" +
                                 $"\n Разница в днях от текущей даты: {(DateTime.Now - date).Days} дней";
            }
            else
            {
                txtResult.Clear();
                MessageBox.Show("Невозможно распознать дату. Данный текст будет обработан, как стандартная строка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Удаление знаков припенания
                string punctuationReplacer = Regex.Replace(inputText, "[-.?!)(,:;]", "");

                // Изменение первой буквы каждого слова на заглавную
                string capitalizedText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(punctuationReplacer.ToLower());

                // Перестановка местами первой и последней буквы в каждом слове
                string swappedText = string.Join(" ", capitalizedText.Split(' ').Select(SwapFirstLastChar));

                // Получение массива слов без пробелов и знаков переноса строки; выводи слов осуществляется в алфавитном порядке
                var words = swappedText.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Distinct()
                                        .OrderBy(w => w)
                                        .ToArray();

                // Сохрание текста в файл
                StreamWriter str = new StreamWriter(filePath);
                for (int a = 0; a < words.Length; a++)
                {
                    str.WriteLine(words[a]);
                }
                str.Close();
                txtResult.Text = $"Файл сохранен по пути: {filePath}";
            }
        }

        private string SwapFirstLastChar(string word)
        {
            if (word.Length <= 1)
                return word;

            char[] charArray = word.ToCharArray();
            charArray[0] = word[word.Length - 1];
            charArray[word.Length - 1] = word[0];
            return new string(charArray);
        }

        // Сортировка файлов в выбранной папке
        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    OrganizeFilesByExtension(selectedPath);
                }
            }
        }

        private void OrganizeFilesByExtension(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                try
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string directoryPath = Path.Combine(path, extension);

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string newFilePath = Path.Combine(directoryPath, Path.GetFileName(file));
                    File.Move(file, newFilePath);
                    txtResult.Text = "Ваши файлы отсортированы по новым папкам.";
                }
                catch (Exception ex)
                {
                    // Игнорирование ошибок и продолжение выполнения сортировки
                    Console.WriteLine($"Ошибка при перемещении {file}: {ex.Message}");
                }
            }
        }

        // Очистка папки по выбранному пути
        private void BtnClearFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    ClearFolder(selectedPath);
                }
            }
        }

        private void ClearFolder(string path)
        {
            try
            {
                // Удаляем все файлы в папке
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }

                // Удаляем все подпапки в папке
                foreach (string dir in Directory.GetDirectories(path))
                {
                    Directory.Delete(dir, true);
                }
                txtResult.Text = ("Содержимое папки успешно удалено.");
            }
            catch (Exception ex)
            {
                txtResult.Text = ($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
