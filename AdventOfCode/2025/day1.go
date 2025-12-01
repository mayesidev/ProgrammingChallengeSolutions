package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func solveD1P1() {
	// Open file, handle errors, close when done
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()

	// Scan line by line
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		d1p1(scanner.Text())
	}

	// Handle scanner errors
	if err := scanner.Err(); err != nil {
		log.Fatal(err)
	}
}

func d1p1(input string) {
	content := input
	fmt.Println(content)
}

func d1p2() {
	fmt.Println("Solve day 1, part 2")
}
