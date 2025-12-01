package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

func solveD1P1() {
	// Open file, handle errors, close when done
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()

	dial := 50
	zeroCount := 0

	// Scan line by line
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		dial = d1p1(dial, scanner.Text())
		if dial == 0 {
			zeroCount++
		}
	}

	fmt.Println("zeroCount: ", zeroCount)

	// Handle scanner errors
	if err := scanner.Err(); err != nil {
		log.Fatal(err)
	}
}

func d1p1(startPos int, input string) int {
	max := 99
	dial := startPos
	dir := input[0]
	amt, err := strconv.Atoi(input[1:])
	if err != nil {
		log.Fatal(err)
	}

	if dir == 'L' {
		dial -= amt
	} else {
		dial += amt
	}

	if dial < 0 {
		dial = max + (dial + 1)
	}

	fmt.Println(startPos, string(dir), amt, dial, dial%100)
	return dial % 100
}

func d1p2() {
	fmt.Println("Solve day 1, part 2")
}
