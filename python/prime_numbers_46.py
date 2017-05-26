# https://www.codeeval.com/open_challenges/46/
import argparse
import math

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('filename')
    args = parser.parse_args()

    with open(args.filename) as f:
        for line in f:
            if line.strip() == "":
                continue
            else:
                comma = ""
                limit = int(line)
                for p in primes():
                    if p >= limit:
                        break
                    else:
                        print(comma + str(p), end = "")
                        comma = ","
            print()

def primes():
    yield 2

    candidate = 3

    while True:
        sq = math.sqrt(candidate)
        isPrime = True
        for i in range(3 , int(sq) + 1):
            if candidate % i == 0:
                isPrime = False
                break
        if isPrime:
            yield candidate

        candidate += 2
if __name__ == '__main__':
    main()