
SET COMMENTS=%1
SET VERSION=%2

git commit -a -m "%COMMENTS%"
git tag %VERSION% -m "%COMMENTS%"
git push origin %VERSION% --no-verify
git push origin