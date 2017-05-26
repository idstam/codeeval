package main

import "log"
import "bufio"
import "os"
import "strconv"
import "fmt"

func main() {
	file, err := os.Open(os.Args[1])
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()
	scanner := bufio.NewScanner(file)
	var sum uint64 = 0

	for scanner.Scan() {
		u, _ := strconv.ParseUint(scanner.Text(), 10, 64)
		sum += u
	}
	fmt.Print(sum)
}
