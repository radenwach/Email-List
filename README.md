Email List Management
Aplikasi CRUD (Create, Read, Update, Delete) sederhana berbasis C# (WinForms) dan MySQL untuk mengelola daftar email.

Fitur
- Menampilkan daftar email dalam bentuk tabel (DataGridView).
- Menambahkan email baru ke database MySQL.
- Mengedit email yang sudah ada.
- Menghapus email dari database.
- Pilih data langsung dari tabel untuk diedit atau dihapus.
- Tampilan tabel otomatis menyesuaikan ukuran jendela.

Teknologi yang Digunakan
- C# (WinForms)
- MySQL Database
- MySQL Connector for .NET
- DataGridView untuk menampilkan data

Struktur Proyek
Email_List
- Form1.cs          # Kode utama aplikasi
- Form1.Designer.cs # Desain UI aplikasi
- Program.cs        # Entry point aplikasi
- email_db.sql      # Skrip database (opsional)
- README.md         # Dokumentasi proyek

Instalasi & Penggunaan
1. Clone Repository
2. Setup Database
   - Buat database MySQL baru dengan nama email_db.
   - Jalankan skrip SQL berikut untuk membuat tabel:
        CREATE DATABASE email_db;
        USE email_db;
        CREATE TABLE emails (
            id INT AUTO_INCREMENT PRIMARY KEY,
            nama VARCHAR(255) NOT NULL,
            email VARCHAR(255) NOT NULL
        );
 3. Jalankan Aplikasi
    - Buka project di Visual Studio
    - Tekan Ctrl + F5 untuk menjalankan aplikasi

 
