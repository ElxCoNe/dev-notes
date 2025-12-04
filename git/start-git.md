# 🧭 GIT-FLUJO-DIARIO.md

## 🚀 Flujo diario de trabajo con Git (develop + features)

Este documento describe cómo trabajar con ramas `feature/...` y
`develop` de forma ordenada, usando buenas prácticas y evitando
conflictos innecesarios.

------------------------------------------------------------------------

## 🕐 1. Empezar el día

### 1️⃣ Actualizar información del remoto (ramas nuevas/borradas)

``` bash
git fetch -p
```

### 2️⃣ Actualizar `develop` local con el remoto

``` bash
git switch develop
git pull
```

### 3️⃣ Cambiar a tu feature existente o crear una nueva

-   Si ya existe tu feature:

``` bash
git switch feature/nombre-de-la-feature
```

-   Si vas a crear una feature nueva:

``` bash
git switch develop
git pull
git switch -c feature/nombre-de-la-feature
```

------------------------------------------------------------------------

## 💻 2. Trabajar en tu feature

``` bash
git status
git add .
git commit -m "feat: descripción clara del cambio"
git push
```

------------------------------------------------------------------------

## 🔄 3. Mantener actualizada tu feature con los cambios del equipo (develop)

### 1️⃣ Actualizar información del remoto

``` bash
git fetch -p
```

### 2️⃣ Actualizar develop local

``` bash
git switch develop
git pull
```

### 3️⃣ Traer cambios de develop a tu feature

``` bash
git switch feature/nombre-de-la-feature
git merge develop
```

Si hay conflictos:

``` bash
git add .
git commit
```

------------------------------------------------------------------------

## ✅ 4. Cuando terminas tu feature

``` bash
git switch feature/nombre-de-la-feature
git status
git push
```

Crear PR en GitHub:

    feature/nombre-de-la-feature → develop

Limpiar repositorio:

``` bash
git fetch -p
git switch develop
git pull
git branch -d feature/nombre-de-la-feature
```

------------------------------------------------------------------------

## 🌙 5. Fin del día sin terminar la feature

``` bash
git switch feature/nombre-de-la-feature
git add .
git commit -m "wip: progreso del día"
git push
git switch develop
```

------------------------------------------------------------------------

## 🧾 CHULETA RÁPIDA

### Empezar el día:

``` bash
git fetch -p
git switch develop
git pull
git switch feature/mi-tarea
```

### Trabajar:

``` bash
git status
git add .
git commit -m "mensaje"
git push
```

### Actualizar tu feature con develop:

``` bash
git fetch -p
git switch develop
git pull
git switch feature/mi-tarea
git merge develop
```

### Terminar feature:

``` bash
git push
git fetch -p
git switch develop
git pull
git branch -d feature/mi-tarea
```