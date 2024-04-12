@echo off
:start
echo Vi igraete v bilyard. Kuda zakatite shar?
echo 1 - Levo
echo 2 - Pravo
set /p var=Variant:
if "%var%" == "1" goto levo1
if "%var%" == "2" goto pravo1

:levo1
echo Vi zakatili shar. Seychas zakatit slozhnee. Kuda katit?
echo 1 - Directly v vlevo
echo 2 - S vikrutasami vpravo
set /p var=Variant:
if "%var%" == "1" goto levo2
if "%var%" == "2" goto pravo2

:pravo1
echo Vi zakatili shar. Seychas zakatit slozhnee. Kuda katit?
echo 1 - Directly v vlevo
echo 2 - S vikrutasami vpravo
set /p var=Variant:
if "%var%" == "1" goto levo2
if "%var%" == "2" goto pravo2

:pravo2
echo Vi sdelali eto! Shar zakachen. Vi pobedili teper vtoroi raund
echo 1 - Directly v centr
echo 2 - S vikrutasami vlevo

echo Kuda katit?
echo 1 - Directly vlevo
echo 2 - S vikrutasami vpravo
set /p var=Variant:
if "%var%" == "1" goto levo3
if "%var%" == "2" goto pravo3

:pravo3
echo Vi sdelali eto! Igra vigrana! teper igrai snova
goto :start

:levo2
echo Vi proigrali i ne zakatili shar
goto :exit

:levo3
echo Vi proigrali i ne zakatili shar
goto :exit

:exit