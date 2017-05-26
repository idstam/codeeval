import argparse

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('filename')
    args = parser.parse_args()

    with open(args.filename) as f:
        for line in f:
            if line.strip() == "":
                continue
            else:
                revWords = ""
                wordCount = 0
                words = line.split()
                for word in reversed(words):
                    revWords += word
                    wordCount += 1
                    if wordCount < len(words):
                        revWords += " "

                print(revWords)
if __name__ == '__main__':
    main()