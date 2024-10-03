# RabbitMQ Exchange Examples

Bu proje, farklı RabbitMQ Exchange türlerini gösteren bir örnek koleksiyonudur. Aşağıdaki exchange türleri, RabbitMQ kullanılarak her bir dizinde ayrı ayrı uygulanmıştır:

- **Direct Exchange**
- **Fanout Exchange**
- **Header Exchange**
- **Topic Exchange**
- **Work Queue**

## Gereksinimler

Projenin çalışması için aşağıdaki araçlara ihtiyaç vardır:

- [Docker](https://www.docker.com/)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- RabbitMQ (Docker ile kurulum talimatı aşağıda verilmiştir)

### RabbitMQ'yu Docker ile Çalıştırma

RabbitMQ'yu Docker üzerinden çalıştırmak için aşağıdaki komutu kullanın:

```
docker run -d -p 5672:5672 -p 15672:15672 --name rabbitmqcontainer rabbitmq:4.0-management
```

Bu komut, RabbitMQ'yu varsayılan portlar (5672 ve 15672) üzerinden çalıştırır. Yönetim paneline erişmek için `http://localhost:15672` adresini ziyaret edebilirsiniz. Varsayılan kullanıcı adı ve şifre `guest/guest`'tir.

## Klasör Yapısı

Her klasörde farklı bir RabbitMQ exchange modeli bulunmaktadır. Bu klasörler içerisinde hem **Publisher** hem de **Subscriber** örnekleri bulunmaktadır. Her birinin nasıl çalıştığı aşağıda açıklanmıştır.

### Direct Exchange

- **Publisher**: Log türüne göre mesajları farklı routing key'ler ile direkt olarak kuyruğa yollar.
- **Subscriber**: Belirli bir routing key'e göre mesajları dinler ve işler.

### Fanout Exchange

- **Publisher**: Tüm subscriber'lara yayın yapar. Routing key kullanmadan mesajları tüm kuyruklara dağıtır.
- **Subscriber**: Tüm gelen mesajları dinler.

### Header Exchange

- **Publisher**: Mesajları header parametrelerine göre iletir.
- **Subscriber**: Header parametrelerine göre mesajları alır.

### Topic Exchange

- **Publisher**: Belirli bir desenle (pattern) routing key'lere göre mesajları yollar.
- **Subscriber**: Belirli bir desene uyan mesajları dinler.

### Work Queue

- **Publisher**: Mesajları kuyruğa gönderir. Mesajlar eşit şekilde işçiler (workers) arasında dağıtılır.
- **Subscriber**: Kuyruktaki mesajları sırayla işler.

## Projeyi Çalıştırma

1. **RabbitMQ'yu Docker ile çalıştırın**:
    ```
    docker run -d -p 5672:5672 -p 15672:15672 --name rabbitmqcontainer rabbitmq:4.0-management
    ```

2. .NET projesini build edin:
    ```
    dotnet build
    ```

3. İlgili klasördeki projeyi çalıştırmak için şu komutu kullanabilirsiniz:
    ```
    dotnet run
    ```

Örnek:

 ```
    cd Direct-exchange/Direct-exchange dotnet run
 ```


Her klasör için bu adımları tekrar edebilirsiniz.
