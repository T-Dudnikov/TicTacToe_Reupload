# TicTacToe Reupload

<b>Задание:</b>  
Игра "Крестики-нолики" с web-интерфейсом и использованием JavaScript.  
Поле 3х3. Необходима запись результатов каждого хода в базу данных MS SQL.  
Реализация на ASP .Net. Без использования LINQ.  
Два варианта:  
1. без использования EntityFramework (или другой ORM, например NHibernate) и с реализацией логики игры на стороне базы данных.  
2. с использованием EntityFramework (или другой ORM, например NHibernate) и с реализацией логики игры на стороне приложения.

Реализовать оба варианта.  
Таблица одна на оба варианта. Количество игровых сессий ограничено тремя.  
Необходимо, чтобы не было конфликтов записей результатов при одновременной игре на всех трех окнах.  
Вывод статистики по выигрышам (крестик - нолик) в виде отчета MS Reporting Services (ReportViewer или другой подсистемы отчетов, Stimulsoft Reports, DevExtreme и т.п.).  
Приложение должно быть разработано под IIS

\
<b>Сделано:</b>
1. Реализован сайт с web-интерфейсом, с использованием js. Играют двое, по очереди выставляя крестики и нолики курсором.
2. Все ходы записываются в базу данных master.dbo.MovesTicTacToe, если она запущена.
3. Нет конфликтов записей результатов при одновременной игре на всех окнах при их разновременной загрузке.
4. Реализован вариант с использованием Dapper и с реализацией логики игры на стороне приложения.
5. Реализован вариант с реализацией логики игры на стороне базы данных

<b>Осталось сделать:</b>.
1. Реализовать вывод статистики.
2. Сделать ограничения на количество игровых сессий.
