# AdessoRideShare

## 1. Bölüm
----
### Endpointler

#### _Kullanıcı sisteme seyahat planını Nereden, Nereye, Tarih ve Açıklama, Koltuk Sayısı bilgileri ile ekleyebilmeli_

* **/SeyahatOlustur**

* **Method:**
 `POST`
  
* **Data Params**

   **Required:**
 
   `Nereden=[string]`
   `Nereye=[string]`
   `KoltukSayisi=[integer]`

   **Optional:**
 
   `kullaniciId=[integer]`
   `yayin=[boolean]`

* **Notes:**

  Kullanıcı id gönderilmezse(0 gönderilirse) yeni bir kullanıcı oluşturulur.
  yayın gönderilmezse false olarak kaydedilir.
----  
#### _Kullanıcı tanımladığı seyahat planını yayına alabilmeli ve yayından kaldırabilmeli_

* **/SeyahatYayinGuncelle**

* **Method:**
 `PUT`
  
* **Data Params**

   **Optional:**
 
   `yayin=[boolean]`
----
#### _Kullanıcılar sistemdeki yayında olan seyahat planlarını Nereden ve Nereye bilgileri ile aratabilmelii_

* **/SeyahatAra**

* **Method:**
 `GET`
  
*  **URL Params**
   **Required:**
 
   `Nereden=[string]`
   `Nereye=[string]`

----  
#### _Kullanıcılar yayında olan seyehat planlarına "Koltuk Sayısı" dolana kadar katılım isteği gönderebilmeli_

* **/SeyahataKatil**

* **Method:**
 `POST`
  
* **Data Params**

   **Required:**
   `seyahatId=[integer]`
   
   **Optional:**
   `kullaniciId=[integer]`

* **Notes:**

  Eğer kullanıcı id gönderilmezse, yeni bir kullanıcı oluşturulur ve seyehate dahil edilir.
  
## 2. Bölüm
----
### Endpointler
  #### Opsiyonel olan ikinci bölümdeki istenen endpointin test edilebilmesi için öncesinde seyahat oluşturmak gerekli

* **/Bolum2/SeyahatOlustur**

* **Method:**
 `POST`
  
* **Data Params**

   **Required:**
 
   `Nereden=[string]`
   `Nereye=[string]`
   `KoltukSayisi=[integer]`

   **Optional:**
 
   `kullaniciId=[integer]`
   `yayin=[boolean]`
----  
#### _Kullanıcılar Nereden ve Nereye bilgileri ile seyahat aradığında bu güzergahtan geçen tüm yayında olan seyahat planlarını bulabilmeli_

* **/Bolum2/GuzergahBul**

* **Method:**
 `GET`
  
*  **URL Params**

   *  **URL Params**
   
   **Required:**
 
   `Nereden=[string]`
   `Nereye=[string]`

 
