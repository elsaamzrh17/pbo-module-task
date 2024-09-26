using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        //membuat objek kebun binatang
        KebunBinatang kebunBinatang = new KebunBinatang();

        //membuat objek hewan dari berbagai jenis
        Singa singa = new Singa("Sino", 6);
        Gajah gajah = new Gajah("Galio", 9);
        Ular ular = new Ular("Nagini", 100, 9.8);
        Buaya buaya = new Buaya("Chico", 8, 4.5);

        //variabel reptil
        Reptil reptil = new Buaya("Chiro", 9, 5);

        //menambahkan hewan ke kebun binatang
        kebunBinatang.TambahHewan(singa);
        kebunBinatang.TambahHewan(gajah);
        kebunBinatang.TambahHewan(ular);
        kebunBinatang.TambahHewan(buaya);

        //menampilkan daftar semua hewa di kebun binatang
        kebunBinatang.DaftarHewan();

        //demonstrasi polymorphism dengan memanggil Suara() dari beberapa hewan
        Console.WriteLine("Demonstrasi Polymorphism: ");
        Console.WriteLine(singa.Suara());
        Console.WriteLine(gajah.Suara());
        Console.WriteLine(ular.Suara());
        Console.WriteLine(buaya.Suara());
        Console.WriteLine(reptil.Suara());

        //memanggil method khusus mengaum dan merayap()
        Console.WriteLine("\nAksi Khusus:");
        singa.Mengaum();
        Console.WriteLine(singa.InfoHewan());
        ular.Merayap();
    }
}

//Class Hewan
public class Hewan
{
    public string nama;
    public int umur;

    public Hewan(string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    public virtual string Suara()
    {
        return "Hewan ini bersuara ";
    }

    public virtual string InfoHewan()
    {
        return $"Hewan: {nama}, berumur: {umur} tahun";
    }
}

//class Mamalia yg mewarisi Hewan, dgn + properti tambahan jumlahKaki
public class Mamalia : Hewan
{
    public int jumlahKaki;

    public Mamalia(string nama, int umur, int jumlahKaki) : base(nama, umur)
    {
        this.jumlahKaki = jumlahKaki;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Jumlah Kaki: {jumlahKaki}";
    }
}


//class Reptil yang mewarisi Hewan, dgn + properti panjangTubuh
public class Reptil : Hewan
{
    public double panjangTubuh;

    public Reptil(string nama, int umur, double panjangTubuh) : base(nama, umur)
    {
        this.panjangTubuh = panjangTubuh;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Panjang Tubuh: {panjangTubuh} meter";
    }
}


//class Singa yg mewarisi Mamalia
public class Singa : Mamalia
{
    public Singa(string nama, int umur) : base(nama, umur, 4) { }

    public override string Suara()
    {
        return "Singa mengaum";
    }

    //method khusus
    public void Mengaum()
    {
        Console.WriteLine($"{nama} sedang mengaum!");
    }
}

//class Gajah yg mewarisi Mamalia
public class Gajah : Mamalia
{
    public Gajah(string nama, int umur) : base(nama, umur, 4) { }

    public override string Suara()
    {
        return "Gajah mengeluarkan suara terompet.";
    }
}


//class Ular yg mewarisi Reptil
public class Ular : Reptil
{
    public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

    public override string Suara()
    {
        return "Ular mendesis.";
    }

    //method khusus
    public void Merayap()
    {
        Console.WriteLine($"{nama} sedang merayap");
    }
}


//class Buaya yg mewarisi Reptil
public class Buaya : Reptil
{
    public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

    public override string Suara()
    {
        return "Buaya mengeram.";
    }
}


//class KebunBinatang yang memiliki koleksi Hewan
public class KebunBinatang
{
    public List<Hewan> KoleksiHewan;

    public KebunBinatang()
    {
        KoleksiHewan = new List<Hewan>();
    }

    public void TambahHewan(Hewan hewan)
    {
        KoleksiHewan.Add(hewan);
    }

    public void DaftarHewan()
    {
        Console.WriteLine("Daftar hewan di kebun binatang: ");
        foreach(var hewan in KoleksiHewan)
        {
            Console.WriteLine($"Nama: {hewan.nama}, Umur: {hewan.umur}");
        }

        Console.WriteLine();
    }
}


