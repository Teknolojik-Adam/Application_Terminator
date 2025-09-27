Application Terminator
Bu proje, çalışan uygulamaları listelemek ve seçilen bir uygulamayı anında sonlandırmak için geliştirilmiş basit bir C# Windows Forms uygulamasıdır.
Projenin Amacı
Bilgisayarda arka planda çalışan veya yanıt vermeyen uygulamaları kolayca yönetmek ve kapatmak için kullanıcı dostu bir arayüz sunmaktır. Görev Yöneticisi'ne alternatif olarak daha hızlı ve odaklanmış bir çözüm sunar.
Geliştirme Süreci ve Fikir
Bu projenin geliştirilmesinde, Mustafa BÜKÜLMEZ'in C# ile süreç yönetimi üzerine yazdığı değerli makalesinden ilham alınmıştır. Projenin temelini oluşturan çalışan bir programı sonlandırma (kill process) mantığı, kendisinin paylaştığı fikirler ve kod örnekleri temel alınarak geliştirilmiştir.
Uygulamanın C#'ta System.Diagnostics.Process sınıfını kullanarak süreçleri nasıl yönetebileceği, çalışan programların nasıl listeleneceği ve process.Kill() metodu ile nasıl sonlandırılacağı konusundaki temel yaklaşım, Mustafa Bükülmez'in makalesinde detaylıca açıklanmaktadır.[1]
Kaynak
Bu projenin geliştirilmesinde ana fikir kaynağı olarak aşağıdaki makale kullanılmıştır:
Makale Adı: C# Kill Proccess – Otomatik Program Kapatmak[1]
Yazar: Mustafa BÜKÜLMEZ
Kaynak URL: https://mustafabukulmez.com/2019/02/28/c-kill-proccess-otomatik-program-kapatmak/
Özellikler
Anlık olarak çalışan tüm süreçleri listeleme.
Listeden seçilen herhangi bir uygulamayı tek tıkla sonlandırma.
Basit ve anlaşılır kullanıcı arayüzü.

Application Terminator
This project is a simple C# Windows Forms application developed to list running applications and instantly terminate a selected one.
Objective
The goal of this project is to provide a user-friendly interface to easily manage and close applications that are running in the background or are unresponsive. 
Development Process and Idea
The development of this project was inspired by a valuable article on process management in C# written by Mustafa BÜKÜLMEZ. The core logic of the application, which involves terminating a running program (the "kill process" functionality), was developed based on the ideas and code examples he shared.
The fundamental approach to managing processes in C# using the System.Diagnostics.Process class, including how to list running programs and how to terminate them with the process.Kill() method, is explained in detail in Mustafa Bükülmez's article.
Source
The following article was used as the main source of inspiration for the development of this project:
Article Title: C# Kill Proccess – Otomatik Program Kapatmak
Author: Mustafa BÜKÜLMEZ
Source URL: https://mustafabukulmez.com/2019/02/28/c-kill-proccess-otomatik-program-kapatmak/
Features
Lists all currently running processes in real-time.
Terminates any selected application from the list with a single click.
Simple and straightforward user interface.
