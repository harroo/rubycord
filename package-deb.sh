mkdir ./pkg/deb/rubycord_V_amd64/opt/
mkdir ./pkg/deb/rubycord_V_amd64/bin/
mkdir ./output.
cp -v ./build/DSharpPlus.dll ./pkg/deb/rubycord_V_amd64/opt/
cp -v ./build/Newtonsoft.Json.dll ./pkg/deb/rubycord_V_amd64/opt/
cp -v ./build/rubycord-bin ./pkg/deb/rubycord_V_amd64/opt/
cp -v ./build/rubycord-link ./pkg/deb/rubycord_V_amd64/bin/rubycord
cd ./pkg/deb
dpkg --build rubycord_V_amd64
mv rubycord_V_amd64.deb ../../output/rubycord_1.0_amd64.deb
cd ../../

