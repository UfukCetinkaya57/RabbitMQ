# RabbitMQ Exchange Türleri Hakkında Detaylı Açıklama

Bu dosya, projede kullanılan RabbitMQ Exchange türleri hakkında daha detaylı bilgi verir ve projeyi kullanırken karşılaşılabilecek temel kavramları açıklar.

## RabbitMQ Nedir?

RabbitMQ, mesajların güvenli ve güvenilir bir şekilde gönderilmesini ve alınmasını sağlayan bir mesaj kuyruğu sistemidir. Çeşitli exchange türleri aracılığıyla mesajları farklı yollarla kuyruklara yönlendirir.

### Exchange Türleri

RabbitMQ, farklı türde exchange modelleri sunar. Her exchange türü, mesajların kuyruklara yönlendirilme şeklini kontrol eder.

#### Direct Exchange

Direct Exchange, belirli bir **routing key** ile mesajları kuyruklara yönlendirir. Mesaj gönderilirken bir routing key belirtilir ve bu anahtarla eşleşen kuyruklara mesaj iletilir.

- **Örnek Kullanım**: Belirli log seviyelerine göre mesajlar ilgili kuyruğa gönderilir (Örneğin: Critical, Error, Warning).
- **Dizin**: `Direct-exchange`

#### Fanout Exchange

Fanout Exchange, mesajları tüm bağlı kuyruğa yönlendirir. Routing key kullanmaz. Yayın (broadcast) tarzı mesajlaşma için idealdir.

- **Örnek Kullanım**: Mesajlar tüm subscriber'lara gönderilir.
- **Dizin**: `Fanout-exchange`

#### Header Exchange

Header Exchange, mesajları header değerlerine göre yönlendirir. Routing key yerine mesajın header bilgileri dikkate alınır.

- **Örnek Kullanım**: Mesajlar belirli header kriterlerine göre yönlendirilir.
- **Dizin**: `Header-exchange`

#### Topic Exchange

Topic Exchange, routing key'lerin bir desen (pattern) ile eşleştiği bir modeldir. `*` ve `#` gibi joker karakterler kullanılarak routing key deseni tanımlanabilir.

- **Örnek Kullanım**: Log mesajları, belirli bir pattern'e göre yönlendirilir (Örneğin: `Warning.*`).
- **Dizin**: `Topic-exchange`

#### Work Queue

Work Queue modeli, kuyruğa eklenen işlerin sırayla işçiler arasında dağıtıldığı bir yapıdır. İş yükünü dengelemek ve eşit dağılım sağlamak amacıyla kullanılır.

- **Örnek Kullanım**: İş yükünü işçiler arasında dağıtmak için kullanılır.
- **Dizin**: `Work-queue`

### Mesajlar ve Kuyruklar

RabbitMQ'da mesajlar kuyruklarda tutulur. Her bir mesaj, bir veya daha fazla kuyruk tarafından işlenir. Kuyruklar, exchange'ler tarafından yönetilen mesajları alır.

### Docker ile RabbitMQ'yu Çalıştırma

RabbitMQ'yu Docker üzerinde çalıştırmak için aşağıdaki komutu kullanabilirsiniz:
```
docker run -d -p 5672:5672 -p 15672:15672 --name rabbitmqcontainer rabbitmq:4.0-management
```

RabbitMQ yönetim paneline `http://localhost:15672` adresinden erişebilirsiniz. Varsayılan kullanıcı adı ve şifre: `guest/guest`.

### RabbitMQ'da Kullanılan Temel Kavramlar

- **Producer (Üretici)**: Mesajları kuyruklara gönderen bileşen.
- **Consumer (Tüketici)**: Mesajları kuyruktan alıp işleyen bileşen.
- **Exchange**: Mesajları belirli kurallar çerçevesinde kuyruğa yönlendiren bileşen.
- **Queue**: Mesajların tutulduğu yapı.
- **Binding**: Bir kuyruk ile exchange arasındaki bağlantı.

