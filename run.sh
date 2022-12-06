rm -rf ./app

dotnet build --configuration Release --output ./app/build
dotnet publish --configuration Release --output ./app/publish

sudo docker build -t "wcftest-${1}" .
sudo docker run -p 80:80 "wcftest-${1}"
