# AntiAD
## Plugin that allows you to prevent advertising in nicknames
Configuration:

```yml
AntiAD:
# Is plugin enabled
  is_enabled: true
  # Should debug (show kick logs in the server console)
  debug: false
  # The action to perform (rename/kick/ban. rename by default)
  action: 'rename'
  # The nickname to replace nicknames containing ads with if the "rename" mode is selected
  nickname: '[ADVERTISEMENT]'
  # Kick message
  kick_msg: '[ANTI AD] Please remove the ads from your nickname and restart the game.'
  # Banned words
  ad:
  - '.com'
  - '.su'
  - '.net'
  - '.ru'
  - '.me'
  - '.ovh'
  - '.xyz'
  - '.site'
  - '.online'
  - '.eu'
  - '.ua'
  - '.shop'
  - '.рф'
  - '.biz'
  - 'twitch'
  - 'yt'
  - 'tw'
  - 'tv'
  - '.tv'
  - '.gg'
  - '.io'
  - '.uy'
  - '.de'
  - '.co'
  - '.uk'
  - '.at'
  - '.kz'
  - '.cz'
```
