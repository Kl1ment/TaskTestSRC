# TaskTestSRC

КОНТРОЛЛЕР Doctor

запрос GET /Doctor/All - возвращает список всех докторов.
    Query-параметры: 
        sortField - указывает по какому полю будет произведена сортировка (fullname, cabinet, specification, districk), дефолтное значение fullname
        page - указывает номер страницы, которую необходимо вернуть (размер страницы 10 запесей, во всех остальных случаях аналогично)

запрос POST /Doctor - создает новую запись доктора с указанием ссылок на соответствующие страницы.
    {
        "fullName": "string",
        "cabinetId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "specificationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "districtId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

запрос PUT /Doctor - изменяет существующую запись доктора.
    Query-параметры:
        doctorId - указывается id доктора, у которого необходимо произвести изменения. Изменения проходят посредствам внесения новых  значений и ссылок
    {
        "fullName": "string",
        "cabinetId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "specificationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "districtId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

запрос DELETE /Doctor - удаляет запись доктора.
    Query-параметры:
        doctorId

запрос GET /Doctor/{id} - возвращает запись доктора с ссылками на соответствующие страницы
    Query-параметры:
        doctorId

запрос GET /Doctor/Appointments - возвращает все записи на прием имеющиеся у доктора
    Query-параметры:
        doctorId


КОНТРОЛЛЕР Patient

запрос GET /Patient/All - возвращает список всех пациентов.
    Query-параметры: 
        sortField - указывает по какому полю будет произведена сортировка (surname, name, patronymic, address, dirthdate, sex, district), дефолтное значение surname
        page

запрос POST /Patient - создает новую запись доктора с указанием ссылок на соответствующие страницы.
    {
        "surname": "string",
        "name": "string",
        "patronymic": "string",
        "address": "string",
        "birthdate": "2024-09-09T12:37:29.126Z",
        "sex": "string",
        "districtId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

запрос PUT /Patient - изменяет существующую запись доктора.
    Query-параметры:
        patientId - указывается id пациента, у которого необходимо произвести изменения. Изменения проходят посредствам внесения новых значений и ссылок
    {
        "surname": "string",
        "name": "string",
        "patronymic": "string",
        "address": "string",
        "birthdate": "2024-09-09T12:37:29.126Z",
        "sex": "string",
        "districtId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

запрос DELETE /Patient - удаляет запись доктора.
    Query-параметры:
        patientId

запрос GET /Patient/{id} - возвращает запись доктора с ссылками на соответствующие страницы
    Query-параметры:
        patientId

запрос GET /Patient/Appointments - возвращает все записи на прием имеющиеся у пациента
    Query-параметры:
        patientId


КОНТРОЛЛЕРЫ Cabinet, District, Specification необходимы для управления соответствующими таблицами.
Все контроллеры работают аналогично и имеют следующие запросы:
    GET - получение списка всех записей
    POST - создание записи
    DELETE - удаление записи по id


КОНТРОЛЛЕР Appointment

GET-запрос /Appointment - возвращает запись на прием по id с ссылками на соответствующие записи
    Query-параметры:
        appointmentId

POST-запрос - создает новую запись на прием
    {
        "patientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "doctorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "dateTime": "2024-09-09T12:45:20.259Z"
    }

PUT-запрос - изменяет запись на прием по id
    Query-параметры:
        appointmentId
    {
        "patientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "doctorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "dateTime": "2024-09-09T12:45:20.259Z"
    }

DELETE-запрос удаляет запись на прием по id