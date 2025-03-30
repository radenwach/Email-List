📧 Email List Management
Aplikasi CRUD (Create, Read, Update, Delete) sederhana berbasis C# (WinForms) dan MySQL untuk mengelola daftar email.

🚀 Fitur
✅ Menampilkan daftar email dalam bentuk tabel (DataGridView).
✅ Menambahkan email baru ke database MySQL.
✅ Mengedit email yang sudah ada.
✅ Menghapus email dari database.
✅ Pilih data langsung dari tabel untuk diedit atau dihapus.
✅ Tampilan tabel otomatis menyesuaikan ukuran jendela.

🛠️ Teknologi yang Digunakan
- C# (WinForms)
- MySQL Database
- MySQL Connector for .NET
- DataGridView untuk menampilkan data

📂 Struktur Proyek
📦 Email_List
 ┣ 📜 Form1.cs          # Kode utama aplikasi
 ┣ 📜 Form1.Designer.cs # Desain UI aplikasi
 ┣ 📜 Program.cs        # Entry point aplikasi
 ┣ 📜 email_db.sql      # Skrip database (opsional)
 ┗ 📜 README.md         # Dokumentasi proyek

📌 Instalasi & Penggunaan
1️⃣ Clone Repository
2️⃣ Setup Database
    1. Buat database MySQL baru dengan nama email_db.
    2. Jalankan skrip SQL berikut untuk membuat tabel:
        CREATE DATABASE email_db;
        USE email_db;
        CREATE TABLE emails (
            id INT AUTO_INCREMENT PRIMARY KEY,
            nama VARCHAR(255) NOT NULL,
            email VARCHAR(255) NOT NULL
        );
  3️⃣ Jalankan Aplikasi
      1. Buka project di Visual Studio
      2. Tekan Ctrl + F5 untuk menjalankan aplikasi

 
