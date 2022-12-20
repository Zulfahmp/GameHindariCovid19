using System;
using System.Collections.Generic;

[Serializable]
public class jsonDataClass
{
    //inisialisasi nama list
    public string listData;
    public List<varianList> result;
    public List<vaksinList> resultVaksin;
    public List<scoreList> resultScore;
    public List<score2> resultScore2;
}

[Serializable]
public class varianList
{
    //isi kolom pada database
    public int id;
    public string jenis_varian;
    public string tanggal;
    public string versi_varian;
    public string negara;
    public string gejala;
    public string audio;
}

[Serializable]
public class vaksinList
{
    //isi kolom pada database
    public int id;
    public string jenis_varian;
    public string tanggal;
    public string versi_varian;
    public string negara;
    public string gejala;
    public string audio;
}

[Serializable]
public class scoreList
{
    public int id;
    public string nama;
    public int score;
}

[Serializable]
public class score2
{
    public int score;
}