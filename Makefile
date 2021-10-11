
#args for main excecutable (for /opt)
main_dep_arg = -r:./lib/DSharpPlus.dll -r:./lib/Newtonsoft.Json.dll
main_src_arg = ./src/*.cs #./src/*/*.cs
main_out_arg = -out:./build/rubycord-bin

#args for linker executable (for /bin)
link_src_arg = ./src/linker/*.cpp
link_out_arg = -o ./build/rubycord-link

#main output event
output: $(main_src_arg) $(link_src_arg)
	mcs $(main_dep_arg) $(main_src_arg) $(main_out_arg)
	g++ $(link_src_arg) $(link_out_arg)

run:
	mono ./build/rubycord-bin

build-portable:
	./package-portable.sh

build-deb:
	./package-deb.sh
