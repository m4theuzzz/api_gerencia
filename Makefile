test:
	export VSTEST_CONNECTION_TIMEOUT=180 \
	dotnet test

check: test
