#  https://www.codeeval.com/open_challenges/156/
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
                toUpper = True
                roller = ""
                for c in line:
                    o = ord(c)
                    if 97 <= o <= 122 or 65 <= o <= 90 :
                        if toUpper and o > 90 :
                            roller += chr(o - 32)
                        elif not toUpper and o < 97 :
                            roller += chr(o + 32)
                        else:
                            roller += c
                    else:
                         roller += c
                         toUpper = not toUpper

                    toUpper = not toUpper
                print(roller, end = "")
if __name__ == '__main__':
    main()