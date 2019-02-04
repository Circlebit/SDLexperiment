using System;
using SDL2;


// https://samulinatri.com/blog/net-core-sdl2-window-creation/

namespace SDLexperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            var window = IntPtr.Zero;
            window = SDL.SDL_CreateWindow("Hallo Leute was geht ab :D",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                1028,
                800,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
                );

            // SDL.SDL_Delay(5000);
            SDL.SDL_Event e;
            bool quit = false;
            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            switch (e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_q:
                                    quit = true;
                                    break;
                            }
                            break;
                    }
                }
            }

            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }
    }
}
