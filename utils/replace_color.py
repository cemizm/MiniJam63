from PIL import Image
import os, fnmatch

colors = ((241, 240, 238 , 255),
          (255, 77, 77 , 255),
          (159, 30, 49 , 255),
          (255, 196, 56 , 255),
          (240, 108, 0 , 255),
          (241, 194, 132 , 255),
          (201, 126, 79 , 255),
          (151, 63, 63 , 255),
          (87, 20, 46 , 255),
          (114, 203, 37 , 255),
          (35, 133, 49 , 255),
          (10, 75, 77 , 255),
          (48, 197, 173 , 255),
          (47, 126, 131 , 255),
          (105, 222, 255 , 255),
          (51, 165, 255 , 255),
          (50, 89, 226 , 255),
          (40, 35, 123 , 255),
          (201, 92, 209 , 255),
          (108, 52, 157 , 255),
          (255, 170, 188 , 255),
          (229, 93, 172 , 255),
          (23, 25, 27 , 255),
          (150, 165, 171 , 255),
          (88, 108, 121 , 255),
          (42, 55, 71 , 255),
          (185, 165, 136 , 255),
          (126, 99, 82 , 255),
          (0, 0, 0 , 0),
          (65, 47, 47, 255))
colors = ((241, 240, 238),
          (255, 77, 77),
          (159, 30, 49),
          (255, 196, 56),
          (240, 108, 0),
          (241, 194, 132),
          (201, 126, 79),
          (151, 63, 63),
          (87, 20, 46),
          (114, 203, 37),
          (35, 133, 49),
          (10, 75, 77),
          (48, 197, 173),
          (47, 126, 131),
          (105, 222, 255),
          (51, 165, 255),
          (50, 89, 226),
          (40, 35, 123),
          (201, 92, 209),
          (108, 52, 157),
          (255, 170, 188),
          (229, 93, 172),
          (23, 25, 27),
          (150, 165, 171),
          (88, 108, 121),
          (42, 55, 71),
          (185, 165, 136),
          (126, 99, 82),
          (0, 0, 0),
          (65, 47, 47))


def find_files(directory, pattern):
    for root, dirs, files in os.walk(directory):
        for basename in files:
            if fnmatch.fnmatch(basename, pattern):
                filename = os.path.join(root, basename)
                yield filename 

def nearest_colour( query ):
    return min( colors, key = lambda subject: sum( (s - q) ** 2 for s, q in zip( subject, query ) ) )


for filename in find_files('Assets/Sprites/', '*.png'):
    im = Image.open(filename)
    pixels = im.load()

    

    if not im.mode == 'RGB' and not im.mode == 'RGBA' and not im.mode == 'P':
        print 'is not rgb: ', filename , ' - ', im.mode
        continue

    print'Replacing: ', filename

    for x in range(im.size[0]):
        for y in range(im.size[1]):
            test = pixels[x, y]
            if type(test) is not int and (len(test) == 3 or test[3] == 255):
                pixels[x, y] = nearest_colour(test)
            else:
                pixels[x, y] = test

    im.save(filename)