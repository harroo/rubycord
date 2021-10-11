
#include<iostream>

int main (int argc, char** argv) {

	std::string cmd = "/opt/rubycord/rubycord-bin";
	
	for (int i = 1; i < argc; ++i) {

		cmd += " ";
		cmd += argv[i];
	}

	system(cmd.c_str());

	return 0;
}
