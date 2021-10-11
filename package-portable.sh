mkdir ./pkg/portable/
mkdir ./output
cp -v ./build/* ./pkg/portable/
rm ./pkg/portable/rubycord-link
cd ./pkg/portable/
tar czvf ../../output/rubycord_portable.tar.xz *
cd ../../
