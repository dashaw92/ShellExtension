# ShellExtension - Jump to non-empty

This extension provides a context menu entry for folders that allows a quick way to skip to the next non-empty folder.

## The problem

While browsing folders, how many times have you had to go through folder after folder to be greeted with, you guessed it, another folder?

GitHub provides a very convinient solution to this and compacts empty folders into a single link:

`"/src/.../somefolder/"`

This extension emulates this behaviour by providing the entry for folders "Jump to non-empty". On click, it opens a new explorer window at the next non-empty folder's path.

## Credits

This extension uses the library SharpShell (https://github.com/dwmkerr/sharpshell)

## License
MIT (See LICENSE)