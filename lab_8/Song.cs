using System;

namespace lab_8
{
    class Song
    {   
        // Домашнее задание 9.1
        private string name;
        private string author;
        private Song prev; 

        // Конструктор 1
        public Song(string songName, string songAuthor)
        {
            name = songName;
            author = songAuthor;
            prev = null; 
        }

        // Конструктор 2
        public Song(string songName, string songAuthor, Song previousSong)
        {
            name = songName;
            author = songAuthor;
            prev = previousSong;
        }

        public Song()
        {
            name = string.Empty;
            author = string.Empty;
            prev = null;
        }

        public void SetName(string songName)
        {
            name = songName;
        }

        public void SetAuthor(string songAuthor)
        {
            author = songAuthor;
        }

        public void SetPrev(Song previousSong)
        {
            prev = previousSong;
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return name == otherSong.name && author == otherSong.author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (name?.GetHashCode() ?? 0) ^ (author?.GetHashCode() ?? 0);
        }
    }

}