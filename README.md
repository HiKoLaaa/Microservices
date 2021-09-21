# Microservices

Схема взамодействия между сервисами:

![alt text](https://github.com/HiKoLaaa/Microservices/blob/master/MicroserviceDiagram.png?raw=true)

- Микросервисы реализованы по шаблону "Database per service".
- Схема БД UserService дублирует схемы AccountService & ProfileService, таким образом БД UserService является read-моделью для клиента и чтение происходит с неё, в то время как запись просходит в другие два сервиса с дублированием записи в UserService.
