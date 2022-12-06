sudo docker build -t "wcftest-${1}" .
sudo docker run -p 80:80 "wcftest-${1}"
