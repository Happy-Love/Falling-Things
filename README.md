# Falling-Things
Это небольшой тест для проверки моих знаний по Unity.
## Игра про падающие коробки.
### Задания
#### Complete
##### Tasks
* Ландшафт представляет собой tilemap. :white_check_mark:
* У игрока есть возможность передвигаться (влево и вправо), и возможность прыгать. :white_check_mark:
* Есть экран, на нём игрок и сверху на игрока падают коробки. :white_check_mark:
* Коробки бывают разные: большие, средние, маленькие  :white_check_mark:
* Коробки должны проваливаться под землю. :white_check_mark:
* У игрока есть анимации передвижения, прыжка и стояния на месте(Idle). :white_check_mark:
* Главное меню – кнопка выхода и запуска. После запуска выбор карты. {Доп. кнопка при выборе карты “Удиви меня(рандомная карта)”}. :white_check_mark:
* Карт несколько. :white_check_mark:
* {Разный урон у коробок, но тогда игроку придётся сделать hp}. :white_check_mark:
* Эффекты- эффект смэрти, {получения урона если есть hp} :white_check_mark:
* {Для интереса добавь бомбы. Бомбы не пролетают сквозь землю и через некоторое время взрываются}. (для коробок отключаем коллайдер если земля, для бомб не отключаем но отключаем если коробка. ) :white_check_mark:
* Cнег на снежной карте, листья. :white_check_mark:
* меню паузы, из которого можно вернуться обратно в основное меню. (escape) :white_check_mark:
* Падающие лечилки. :white_check_mark:
* полоска здоровья. :white_check_mark:
* Игровой таймер т.е. раунд начался и начался отсчёт. :white_check_mark:
* количество заработанных монет, кнопка выхода в меню. :white_check_mark:
* Смэрть игрока: после смэрти появляется табло с временем(сколько игрок секунд прожил). :white_check_mark:
##### Fixed
* Границы экрана, убрать crounch.
##### Refactoring
* В корутине поменяй рекурсию на бесконечный цикл 
* Семантика в названии переменных(Придерживаться определнного шаблона)
* Названия классов 
* Добавить игроку maxHealth
#### Development
##### Добавить: 
* спавн монеток.
* Падающие сундучки - они наносят урон если попадут на игрока, но если на них кликнуть определённое количество раз, то сундук откроется и игроку дадут(не выпадают, а сразу дают) монетки, после открытия сундук исчезает.
* У сундука шанс спавна меньше чем у чего либо(Вероятность у объектов отныне в инспекторе задаётся).
* Для монеток реализовать спавн в пределах досягаемости игрока и исчезают через некоторое время, если игрок их не успел подобрать.
* Сохранение количества монет у игрока(не через PlayerPrefs).
#### Production
* После дедлайна мы смотрим производительность проекта и пытаемся его немного оптимизировать (научимся юзать profiler).