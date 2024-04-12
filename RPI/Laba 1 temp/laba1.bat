@echo off
:start
echo Vi reshaete uravnenie genialnoe
echo 1 - Poschitat integral
echo 2 - Vichislit cosinus
echo 3 - Umnozhit drobi
echo 4 - Poluchit interval
set /p var=Variant:
if "%var%" == "1" goto next
if "%var%" == "3" goto next
if "%var%" == "2" goto next
if "%var%" == "4" goto next

:next
echo Uravnenie pochti poschitano no otveti ne te. Chto sdelat dalshe
echo 1 - Proverit vse svoi shagi
echo 2 - Prodolzhit podschet
set /p var=Variant:
if "%var%" == "1" goto exit
if "%var%" == "2" goto back

:back
echo Vashi proscheti v korne ne verni! Pridetsa schitat zanovo
goto start

:exit
    echo Vi poshchitali vse pravilno i polychili nobelevskuu premiu!!!