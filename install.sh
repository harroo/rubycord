echo "installing rubycord..."
mkdir /opt/rubycord/
cp -v ./build/DSharpPlus.dll /opt/rubycord/
cp -v ./build/Newtonsoft.Json.dll /opt/rubycord/
cp -v ./build/rubycord-bin /opt/rubycord/
cp -v ./build/rubycord-link /bin/rubycord
echo "successfully installed rubycord"
